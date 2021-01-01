using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ProvinceController : Controller
    {
        public IActionResult Index()
        {
            return Content("Elenco province italiane");
        }

        public IActionResult Dettaglio(string id)
        {
            return View();
        }
    }
}