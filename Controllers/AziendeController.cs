using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class AziendeController : Controller
    {
        private readonly IAziendaService aziendaService;
        public AziendeController(IAziendaService aziendaService)
        {
            this.aziendaService = aziendaService;
        }
        
        public async Task<IActionResult> Dettaglio()
        {
            AziendaViewModel azienda = await aziendaService.GetAziendaAsync();
            ViewBag.Title = "Configurazione società concessionaria";
            if(azienda != null)
            {
                return View(azienda);
            }
            else return null; //RedirectToAction(nameof(Create));
        }
/*
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Configurazione Ente";
            EnteViewModel ente = await enteService.GetEnteAsync();
            if(ente==null) 
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
            EnteViewModel ente = await enteService.CreateEnteAsync(inputModel);
            return RedirectToAction(nameof(Dettaglio));
        }

        public async Task<IActionResult> ModifySedeLegale()
        {
            ViewBag.Title = "Configurazione sede legale";
            EnteViewModel ente = await enteService.GetEnteAsync();
            if(ente!=null) 
            {
                EnteViewModel enteViewModel = await enteService.GetEnteAsync();
                var inputModel = new EnteModifyInputModel();
                inputModel.CodiceCatastale = enteViewModel.CodiceCatastale;
                inputModel.Toponimo = enteViewModel.Toponimo;
                inputModel.Indirizzo = enteViewModel.Indirizzo;
                inputModel.Civico = enteViewModel.Civico;
                inputModel.Lettera = enteViewModel.Lettera;
                inputModel.Localita = enteViewModel.Localita;
                inputModel.PartitaIva = enteViewModel.PartitaIva;
                inputModel.CodiceFiscale = enteViewModel.CodiceFiscale;
                inputModel.Telefono = enteViewModel.Telefono;
                inputModel.Fax = enteViewModel.Fax;
                inputModel.Email = enteViewModel.Email;
                inputModel.Pec = enteViewModel.Pec;
                inputModel.TitoloResponsabile = enteViewModel.TitoloResponsabile;
                inputModel.CognomeResponsabile = enteViewModel.CognomeResponsabile;
                inputModel.NomeResponsabile = enteViewModel.NomeResponsabile;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifySedeLegale(EnteModifyInputModel inputModel)
        {
            ViewBag.Title = "Configurazione sede legale";
            if (ModelState.IsValid)
            {
                EnteViewModel ente = await enteService.ModifyEnteAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="One"});
            }
            return View(inputModel);
        }
*/
    }
}