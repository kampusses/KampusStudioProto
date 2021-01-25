using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Kampus Studio - Ver. Proto";
            return View();
        }
    }
}