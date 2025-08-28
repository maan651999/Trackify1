using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackify.Application.DTOs;
using Trackify.Application.Interfaces;
using Trackify.Infrastructure;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IExpenseRepository _expenseService;
        private readonly IBudgetService _budgetService;
        private readonly IMonthlyBudgetRepository _budgetRepository;
        private readonly INutritionRepository _nutrition;
        protected int UserId => Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        private ISession Session => HttpContext.Session;
        public DashboardController(INutritionRepository nutrition, AppDbContext context, IExpenseRepository expenseService, IBudgetService budgetService, IMonthlyBudgetRepository budgetRepository)
        {
            _context = context;
            _expenseService = expenseService;
            _budgetService = budgetService;
            _budgetRepository = budgetRepository;
            _nutrition = nutrition;
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                var data = await _expenseService.GetExpensesByMonthAsync(UserId,  year);
                var budget = await _budgetRepository.GetByUserAndMonthAsync(UserId, year);
                ViewBag.Month = month;
                ViewBag.Year = year;
                ViewBag.Date = DateTime.Now;
                if (budget != null && data.FirstOrDefault() != null)
                {
                    ViewBag.Budget = budget.Amount;
                    ViewBag.Total = data.Sum(e => e.Amount);
                }
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("/Dashboard/UploadPhoto")]
        public async Task<IActionResult> UploadPhoto()
        {
            try
            {
                UserPhotoUploadDto dto = new UserPhotoUploadDto();
                return View(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("/Dashboard/UploadPhoto")]
        public async Task<IActionResult> UploadPhoto(UserPhotoUploadDto dto)
        {
            try
            {
                if (dto.PhotoFile == null || dto.PhotoFile.Length == 0)
                {
                    ModelState.AddModelError("", "Please select a file.");
                    return View(dto);
                }

                var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp" };
                if (!allowedTypes.Contains(dto.PhotoFile.ContentType.ToLower()))
                {
                    ModelState.AddModelError("", "Only JPG, PNG, and WEBP files are allowed.");
                    return View(dto);
                }

                if (dto.PhotoFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "File size must be under 2MB.");
                    return View(dto);
                }

                // ✅ Save file
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.PhotoFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.PhotoFile.CopyToAsync(stream);
                }
                var user = await _context.Users.FindAsync(UserId);
                if (user != null)
                {
                    user.PhotoUrl = "/images/" + uniqueFileName;
                    await _context.SaveChangesAsync();
                    HttpContext.Session.SetString("UserPhoto", user.PhotoUrl);
                }
                return RedirectToAction("Dashboard", "Dashboard");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Index(DateTime? date = null)
        {
            var today = (date ?? DateTime.UtcNow).Date;
            var user = await _context.Users.FirstAsync(); // single-user app seed (Mohit)
            var totals = await _nutrition.GetDailyTotalsAsync(user.UserId, today);

            // Today workout (by week number)
            var weeksSinceStart = (int)Math.Ceiling((today - user.CreatedDate.Date).TotalDays / 7.0);
            var week = Math.Clamp(weeksSinceStart, 1, 8);
            var workout = await _context.Workouts.Include(w => w.Exercises)
                .Where(w => w.UserId == user.UserId && w.WeekNumber == week && w.DayOfWeek == today.DayOfWeek)
                .FirstOrDefaultAsync();

            ViewBag.User = user;
            ViewBag.Date = today;
            ViewBag.Protein = totals.protein;
            ViewBag.Calories = totals.calories;
            ViewBag.Workout = workout;
            return View();
        }
    }
}
