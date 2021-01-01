using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class CapController : Controller
    {
        public IActionResult Index()
        {
            return Content("Gestione Cap non ancora implementata.");
        }

        public IActionResult Dettaglio(string id)
        {
            return View();
        }
    }
}