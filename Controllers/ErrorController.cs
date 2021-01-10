using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Titolo = "Errore";
            return View();
        }
    }
}