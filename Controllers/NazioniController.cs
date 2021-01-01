using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class NazioniController : Controller
    {
        public IActionResult Index()
        {
            return Content("Elenco nazioni estere");
        }

        public IActionResult Dettaglio(string id)
        {
            return View();
        }
    }
}