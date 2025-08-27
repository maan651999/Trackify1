using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;
using Trackify.Application.DTOs;
using Trackify.Application.Interfaces;
using Trackify.Domain.Entities;
using Trackify.Infrastructure;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMonthlyBudgetRepository _budgetRepository;
        private ISession Session => HttpContext.Session;
        public AccountController(AppDbContext context,IMonthlyBudgetRepository monthlyBudgetRepository)
        {
            _context = context;
            _budgetRepository = monthlyBudgetRepository;
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
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _context.Users
                        .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

                    if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, user.PasswordHash))
                    {
                        TempData["LoginError"] = "Invalid credentials. Please try again.";
                        ModelState.AddModelError("", "Invalid Email or Password");
                        return View(loginDto);
                    }

                    // Update login info
                    user.LastLoginDate = DateTime.Now;
                    user.LastLoginIP = HttpContext.Connection.RemoteIpAddress?.ToString();
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    // ✅ JWT Generate
                    string role = user.FullName; // Ideally role should come from Role field, not FullName
                    var jwtToken = Authentication.GenerateJWTAuthentication(user.Email, role);
                    var validUserName = Authentication.ValidateToken(jwtToken);

                    if (string.IsNullOrEmpty(validUserName))
                    {
                        ModelState.AddModelError("", "Unauthorized login attempt");
                        return View(loginDto);
                    }
                    // ✅ Save JWT in Cookie (ASP.NET Core way)
                    Response.Cookies.Append("jwt", jwtToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, // Enable only if HTTPS
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(60) // Token expiry
                    });
                    // ✅ JWT ko decode karke expiry nikalna
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken2 = handler.ReadToken(jwtToken) as JwtSecurityToken;
                    if (jwtToken2 != null)
                    {
                        HttpContext.Session.SetString("jwtExpiry", jwtToken2.ValidTo.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                    }
                    // ✅ Store user info in Session
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("UserName", user.FullName);
                    HttpContext.Session.SetString("UserPhoto", user.PhotoUrl ?? "/images/default.png");
                    // ✅ Load user budget
                    var existing = await _budgetRepository.GetByUserAndMonthAsync(user.UserId, DateTime.Now.Year);
                    HttpContext.Session.SetInt32("UserBudget", Convert.ToInt32(existing?.Amount ?? 0));
                    // ✅ Success message
                    TempData["LoginSuccess"] = $"Welcome back, {user.FullName}!";
                    return RedirectToAction("LoggedIn", "Account");
                }
                return View(loginDto);
            }
            catch (Exception ex)
            {
                // ✅ Log error (Serilog / ILogger recommended)
                return StatusCode(500, new { message = "Login failed", error = ex.Message });
            }
        }
        [JwtAuthentication]
        public ActionResult LoggedIn()
        {
            if (Session.GetInt32("UserId") != null)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        [HttpGet("/Account/Logout")]
        public IActionResult Logout()
        {
            try
            {
                TempData["LogoutSuccess"] = "You have been logged out successfully.";
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
