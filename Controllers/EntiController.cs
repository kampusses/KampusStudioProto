using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class EntiController : Controller
    {
        private readonly IEnteService enteService;
        public EntiController(IEnteService enteService)
        {
            this.enteService = enteService;
        }
        
        public async Task<IActionResult> Dettaglio()
        {
            EnteViewModel ente = await enteService.GetEnteAsync();
            ViewBag.Title = "Configurazione Ente";
            if(ente.CodiceCatastale!="") return View(ente);
            else return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Configurazione Ente";
            EnteViewModel ente = await enteService.GetEnteAsync();
            if(ente.CodiceCatastale=="") 
            {
                var inputModel= new EnteCreateInputModel();
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnteCreateInputModel inputModel)
        {
            ViewBag.Title = "Configurazione Ente";
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            EnteViewModel ente = await enteService.CreaEnteAsync(inputModel);
            return RedirectToAction(nameof(Dettaglio));
        }

        public async Task<IActionResult> ModifySedeLegale()
        {
            ViewBag.Title = "Configurazione sede legale";
            EnteViewModel ente = await enteService.GetEnteAsync();
            if(ente.CodiceCatastale!="") 
            {
                var inputModel= new EnteModifyInputModel();
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

    }
}