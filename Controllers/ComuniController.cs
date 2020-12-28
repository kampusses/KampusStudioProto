using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono Index");
        }

        public IActionResult Dettaglio(string id)
        {
            return Content($"Sono Dettaglio ed ho ricevuto l'id {id}");
        }
    }
}