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
            EnteViewModel ente = await enteService.GetEnteAsync();
            ViewBag.Title = "Configurazione Ente";
            if(ente.CodiceCatastale=="") return View();
            else
            {
                var inputModel= new EnteCreateInputModel();
                return View(inputModel);
            }
        }
    }
}