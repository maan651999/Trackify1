using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Trackify.Application.DTOs;
using Trackify.Application.Interfaces;
using Trackify.Domain.Entities;
using Trackify.Infrastructure;
using Trackify.Web.Filters;
using static Trackify.Application.DTOs.GoogleCaptchaResponse;

namespace Trackify.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMonthlyBudgetRepository _budgetRepository;
        private readonly ITokenService _tokenService;
        // Dummy storage (DB recommend)
        private readonly Dictionary<string, string> _refreshTokens = new();
        private ISession Session => HttpContext.Session;
        private static IConfiguration _config;
        public static void Initialize(IConfiguration config)
        {
            _config = config;
        }
        public AccountController(AppDbContext context, IMonthlyBudgetRepository monthlyBudgetRepository, ITokenService tokenService)
        {
            _context = context;
            _budgetRepository = monthlyBudgetRepository;
            _tokenService = tokenService;
        }
        [HttpGet]
        public ActionResult Register()
        {
            Session.Clear();
            return View();
        }
        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
                    _context.Add(user);
                    _context.SaveChanges();

                    TempData["RegisterSuccess"] = "You have registered successfully!";
                    return RedirectToAction("Login", "Account");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["RegisterError"] = "Something went wrong. Please try again.";
                return StatusCode(500, new { Message = "An error occurred while saving the user.", Details = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var captchaService = new CaptchaService(_config);

            if (string.IsNullOrEmpty(captchaResponse) || !await captchaService.VerifyCaptchaAsync(captchaResponse))
            {
                TempData["LoginError"] = "Captcha verification failed. Please try again.";
                return View(loginDto);
            }

            if (!ModelState.IsValid)
                return View(loginDto);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, user.PasswordHash))
            {
                var existing = await _budgetRepository.GetByUserAndMonthAsync(user.UserId, DateTime.Now.Year);

                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("UserName", user.FullName);                
                HttpContext.Session.SetInt32("UserBudget", Convert.ToInt32(existing?.Amount ?? 0));
                HttpContext.Session.SetString("UserPhoto", user.PhotoUrl ?? "/images/default.png");

                TempData["LoginSuccess"] = $"Welcome back, {user.FullName}!";

                user.LastLoginDate = DateTime.UtcNow;
                user.LastLoginIP = HttpContext.Connection.RemoteIpAddress?.ToString();
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                // ✅ always use Email as key
                await JwtRefreshMiddleware.RefreshForUserAsync(HttpContext, _tokenService, _refreshTokens, user.Email);
                return RedirectToAction("LoggedIn", "Account");
            }

            TempData["LoginError"] = "Invalid credentials. Please try again.";
            return View(loginDto);
        }

        [JwtAuthentication]
        public ActionResult LoggedIn()
        {
            return Session.GetInt32("UserId") != null
                ? RedirectToAction("Dashboard", "Dashboard")
                : RedirectToAction("Login", "Account");
        }

        [HttpGet("/Account/Logout")]
        public IActionResult Logout()
        {
            TempData["LogoutSuccess"] = "You have been logged out successfully.";
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
