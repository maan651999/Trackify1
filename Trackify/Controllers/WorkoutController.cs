using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackify.Infrastructure;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class WorkoutController : Controller
    {
        private readonly AppDbContext _db;
        protected int UserId => Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        public WorkoutController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Today()
        {
            var user = await _db.Users.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
            var today = DateTime.UtcNow.Date;
            var weeksSinceStart = (int)Math.Ceiling((today - user.CreatedDate.Date).TotalDays / 7.0);
            var week = Math.Clamp(weeksSinceStart, 1, 8);
            var wd = await _db.Workouts.Include(w => w.Exercises)
                .FirstOrDefaultAsync(w => w.UserId == user.UserId && w.WeekNumber == week && w.DayOfWeek == today.DayOfWeek);
            return View(wd);
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(int exerciseId)
        {
            var ex = await _db.Exercises.FindAsync(exerciseId);
            if (ex != null) { ex.Completed = !ex.Completed; await _db.SaveChangesAsync(); }
            return RedirectToAction("Today");
        }
    }
}
