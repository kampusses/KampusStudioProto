using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
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
        public async Task<IActionResult> Index(ComuneListInputModel model)
        {
            List<ComuneViewModel> comuni = await comuneService.GetComuniAsync(model);
            ViewBag.Titolo = "Comuni italiani";
            return View(comuni);
        }

        public async Task<IActionResult> Dettaglio(string id)
        {
            ComuneViewModel comune = await comuneService.GetComuneAsync(id);
            ViewBag.Titolo = "Comune di " + comune.NomeComune;
            return View(comune);
        }
    }
}