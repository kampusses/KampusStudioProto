using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Solo la index della home");
        }
    }
}