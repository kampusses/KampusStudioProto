using System.Collections.Generic;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            var comuneService = new ComuneService();
            List<ComuneViewModel> comuni = comuneService.GetComuni();
            ViewBag.Titolo = "Comuni italiani";
            return View(comuni);
        }

        public IActionResult Dettaglio(string id)
        {
            var comuneService = new ComuneService();
            ComuneViewModel comune = comuneService.GetComune(id);
            ViewBag.Titolo = "Comune di " + comune.NomeComune;
            return View(comune);
        }
    }
}