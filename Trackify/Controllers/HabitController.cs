using Microsoft.AspNetCore.Mvc;
using Trackify.Web.Filters;

namespace Trackify.Web.Controllers
{
    [SessionCheck]
    public class HabitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
