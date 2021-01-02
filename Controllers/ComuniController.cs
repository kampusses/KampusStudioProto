using System.Collections.Generic;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ComuniController : Controller
    {
        private readonly IComuneService comuneService;
        public ComuniController(IComuneService comuneService)
        {
            this.comuneService = comuneService;
        }
        public IActionResult Index()
        {
            List<ComuneViewModel> comuni = comuneService.GetComuni();
            ViewBag.Titolo = "Comuni italiani";
            return View(comuni);
        }

        public IActionResult Dettaglio(string id)
        {
            ComuneViewModel comune = comuneService.GetComune(id);
            ViewBag.Titolo = "Comune di " + comune.NomeComune;
            return View(comune);
        }
    }
}