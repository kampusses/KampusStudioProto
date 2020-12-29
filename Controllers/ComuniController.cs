using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dettaglio(string id)
        {
            return View();
        }
    }
}