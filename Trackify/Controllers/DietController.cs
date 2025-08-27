using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackify.Domain.FitnessEntity;
using Trackify.Infrastructure;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class DietController : Controller
    {
        private readonly AppDbContext _db;
        public DietController(AppDbContext db) => _db = db;
        public async Task<IActionResult> Index(DateTime? date = null)
        {
            var d = (date ?? DateTime.UtcNow).Date;
            var user = await _db.Users.FirstAsync();
            var meals = await _db.Meals.Where(m => m.UserId == user.UserId && m.MealTime == d).OrderBy(m => m.MealType).ToListAsync();
            ViewBag.Date = d; ViewBag.User = user;
            return View(meals);
        }

        [HttpGet]
        public IActionResult Add(DateTime? date = null)
        {
            ViewBag.Date = (date ?? DateTime.UtcNow).Date;
            return View(new Meal { MealTime = ViewBag.Date });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Meal meal)
        {
            var user = await _db.Users.FirstAsync();
            meal.UserId = user.UserId;
            _db.Meals.Add(meal);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", new { date = meal.MealTime });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var m = await _db.Meals.FindAsync(id);
            if (m != null) { var dt = m.MealTime; _db.Meals.Remove(m); await _db.SaveChangesAsync(); return RedirectToAction("Index", new { date = dt }); }
            return RedirectToAction("Index");
        }
    }
}
