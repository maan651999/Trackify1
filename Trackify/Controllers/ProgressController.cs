using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackify.Domain.FitnessEntity;
using Trackify.Infrastructure;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class ProgressController : Controller
    {
        private readonly AppDbContext _db;
        public ProgressController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var user = await _db.Users.FirstOrDefaultAsync();
            var logs = await _db.Progresses.Where(p => p.UserId == user.UserId).OrderByDescending(p => p.Date).ToListAsync();
            ViewBag.User = user;
            return View(logs);
        }

        [HttpGet]
        public IActionResult Add() => View(new Progress { Date = DateTime.UtcNow.Date });

        [HttpPost]
        public async Task<IActionResult> Add(Progress log)
        {
            var user = await _db.Users.FirstAsync();
            log.UserId = user.UserId;
            _db.Progresses.Add(log);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
