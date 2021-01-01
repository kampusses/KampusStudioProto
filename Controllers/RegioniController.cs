using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class RegioniController : Controller
    {
        public IActionResult Index()
        {
            return Content("Elenco regioni italiane");
        }

        public IActionResult Dettaglio(string id)
        {
            return View();
        }
    }
}