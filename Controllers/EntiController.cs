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
        
        public async Task<IActionResult> Dettaglio(string card)
        {
            EnteViewModel ente = await enteService.GetEnteAsync();
            ViewBag.Title = "Configurazione Ente";
            if(ente != null)
            {
                ente.Card = card;
                return View(ente);
            }
            else return RedirectToAction(nameof(Create));
        }

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
            EnteViewModel enteViewModel = await enteService.GetEnteAsync();
            if(enteViewModel!=null) 
            {
                var inputModel = new EnteModifySedeLegaleInputModel();
                inputModel.CodiceCatastale = enteViewModel.CodiceCatastale;
                inputModel.Toponimo = enteViewModel.Toponimo;
                inputModel.Indirizzo = enteViewModel.Indirizzo;
                inputModel.Civico = enteViewModel.Civico;
                inputModel.Lettera = enteViewModel.Lettera;
                inputModel.Localita = enteViewModel.Localita;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifySedeLegale(EnteModifySedeLegaleInputModel inputModel)
        {
            ViewBag.Title = "Configurazione sede legale";
            if (ModelState.IsValid)
            {
                EnteViewModel ente = await enteService.ModifyEnteAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="One"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyDatiFiscali()
        {
            ViewBag.Title = "Configurazione dati fiscali";
            EnteViewModel enteViewModel = await enteService.GetEnteAsync();
            if(enteViewModel!=null) 
            {
                var inputModel = new EnteModifyDatiFiscaliInputModel();
                inputModel.CodiceCatastale = enteViewModel.CodiceCatastale;
                inputModel.PartitaIva = enteViewModel.PartitaIva;
                inputModel.CodiceFiscale = enteViewModel.CodiceFiscale;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyDatiFiscali(EnteModifyDatiFiscaliInputModel inputModel)
        {
            ViewBag.Title = "Configurazione dati fiscali";
            if (ModelState.IsValid)
            {
                EnteViewModel ente = await enteService.ModifyEnteAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Two"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyContatti()
        {
            ViewBag.Title = "Configurazione contatti ente";
            EnteViewModel enteViewModel = await enteService.GetEnteAsync();
            if(enteViewModel!=null) 
            {
                var inputModel = new EnteModifyContattiInputModel();
                inputModel.CodiceCatastale = enteViewModel.CodiceCatastale;
                inputModel.Telefono = enteViewModel.Telefono;
                inputModel.Fax = enteViewModel.Fax;
                inputModel.Email = enteViewModel.Email;
                inputModel.Pec = enteViewModel.Pec;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyContatti(EnteModifyContattiInputModel inputModel)
        {
            ViewBag.Title = "Configurazione contatti ente";
            if (ModelState.IsValid)
            {
                EnteViewModel ente = await enteService.ModifyEnteAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Three"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyResponsabile()
        {
            ViewBag.Title = "Configurazione funzionario responsabile";
            EnteViewModel enteViewModel = await enteService.GetEnteAsync();
            if(enteViewModel!=null) 
            {
                var inputModel = new EnteModifyResponsabileInputModel();
                inputModel.CodiceCatastale = enteViewModel.CodiceCatastale;
                inputModel.TitoloResponsabile = enteViewModel.TitoloResponsabile;
                inputModel.CognomeResponsabile = enteViewModel.CognomeResponsabile;
                inputModel.NomeResponsabile = enteViewModel.NomeResponsabile;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyResponsabile(EnteModifyResponsabileInputModel inputModel)
        {
            ViewBag.Title = "Configurazione funzionario responsabile";
            if (ModelState.IsValid)
            {
                EnteViewModel ente = await enteService.ModifyEnteAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Four"});
            }
            return View(inputModel);
        }
    }
}