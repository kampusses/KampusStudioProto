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
            ViewBag.Title = "Azienda concessionaria";
            if(azienda != null)
            {
                return View(azienda);
            }
            else return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Azienda concessionaria";
            AziendaViewModel azienda = await aziendaService.GetAziendaAsync();
            if(azienda==null) 
            {
                var inputModel= new AziendaCreateInputModel();
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AziendaCreateInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria";
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            AziendaViewModel azienda = await aziendaService.CreateAziendaAsync(inputModel);
            return RedirectToAction(nameof(Dettaglio));
        }
/*
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