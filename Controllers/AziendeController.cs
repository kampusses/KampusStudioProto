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
        
        public async Task<IActionResult> Dettaglio(string card)
        {
            AziendaViewModel azienda = await aziendaService.GetAziendaAsync();
            ViewBag.Title = "Azienda concessionaria";
            if(azienda != null)
            {
                azienda.Card = card;
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

        public async Task<IActionResult> ModifyNomeAzienda()
        {
            ViewBag.Title = "Azienda condessionaria";
            AziendaViewModel azienda = await aziendaService.GetAziendaAsync();
            if(azienda!=null) 
            {
                AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
                var inputModel = new AziendaModifyNomeAziendaInputModel();
                inputModel.NomeAzienda = aziendaViewModel.NomeAzienda;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyNomeAzienda(AziendaModifyNomeAziendaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyNomeAziendaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Zero"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyIndirizzoAzienda()
        {
            ViewBag.Title = "Azienda condessionaria";
            AziendaViewModel azienda = await aziendaService.GetAziendaAsync();
            if(azienda!=null) 
            {
                AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
                var inputModel = new AziendaModifyIndirizzoAziendaInputModel();
                inputModel.ToponimoAzienda = aziendaViewModel.ToponimoAzienda;
                inputModel.IndirizzoAzienda = aziendaViewModel.IndirizzoAzienda;
                inputModel.CivicoAzienda = aziendaViewModel.CivicoAzienda;
                inputModel.LetteraAzienda = aziendaViewModel.LetteraAzienda;
                inputModel.LocalitaAzienda = aziendaViewModel.LocalitaAzienda;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyIndirizzoAzienda(AziendaModifyIndirizzoAziendaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyIndirizzoAziendaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Zero"});
            }
            return View(inputModel);
        }
    }
}