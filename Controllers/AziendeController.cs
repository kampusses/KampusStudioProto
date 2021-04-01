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
        private readonly IComuneService comuneService;
        public AziendeController(IAziendaService aziendaService, IComuneService comuneService)
        {
            this.aziendaService = aziendaService;
            this.comuneService = comuneService;
        }
        
        public async Task<IActionResult> Dettaglio(string card)
        {
            AziendaViewModel azienda = await aziendaService.GetAziendaAsync();
            ViewBag.Title = "Azienda concessionaria";
            if(azienda != null)
            {
                string codiceCatastale = azienda.CittaAzienda.CodiceCatastale;
                ComuneViewModel cittaAzienda = await comuneService.GetCodiceCatastaleComuneAsync(codiceCatastale);
                azienda.CittaAzienda = cittaAzienda;
                codiceCatastale = azienda.CittaAgenzia.CodiceCatastale;
                ComuneViewModel cittaAgenzia = await comuneService.GetCodiceCatastaleComuneAsync(codiceCatastale);
                azienda.CittaAgenzia = cittaAgenzia;
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
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
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
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyIndirizzoAziendaInputModel();
                inputModel.ToponimoAzienda = aziendaViewModel.ToponimoAzienda;
                inputModel.IndirizzoAzienda = aziendaViewModel.IndirizzoAzienda;
                inputModel.CivicoAzienda = aziendaViewModel.CivicoAzienda;
                inputModel.LetteraAzienda = aziendaViewModel.LetteraAzienda;
                inputModel.LocalitaAzienda = aziendaViewModel.LocalitaAzienda;
                ComuneViewModel comune = await comuneService.GetCodiceCatastaleComuneAsync(aziendaViewModel.CittaAzienda.CodiceCatastale);
                inputModel.CittaAzienda = comune.NomeComune;
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

        public async Task<IActionResult> ModifyCfPivaAzienda()
        {
            ViewBag.Title = "Azienda condessionaria";
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyCfPivaAziendaInputModel();
                inputModel.CodiceFiscaleAzienda = aziendaViewModel.CodiceFiscaleAzienda;
                inputModel.PartitaIvaAzienda = aziendaViewModel.PartitaIvaAzienda;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyCfPivaAzienda(AziendaModifyCfPivaAziendaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyCfPivaAziendaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Zero"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyTelefonoFaxAzienda()
        {
            ViewBag.Title = "Azienda condessionaria";
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyTelefonoFaxAziendaInputModel();
                inputModel.TelefonoAzienda = aziendaViewModel.TelefonoAzienda;
                inputModel.FaxAzienda = aziendaViewModel.FaxAzienda;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyTelefonoFaxAzienda(AziendaModifyTelefonoFaxAziendaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyTelefonoFaxAziendaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Zero"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyEmailPecAzienda()
        {
            ViewBag.Title = "Azienda condessionaria";
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyEmailPecAziendaInputModel();
                inputModel.EmailAzienda = aziendaViewModel.EmailAzienda;
                inputModel.PecAzienda = aziendaViewModel.PecAzienda;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyemailPecAzienda(AziendaModifyEmailPecAziendaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyEmailPecAziendaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="Zero"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyIndirizzoAgenzia()
        {
            ViewBag.Title = "Azienda condessionaria - Agenzia locale";
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyIndirizzoAgenziaInputModel();
                inputModel.ToponimoAgenzia = aziendaViewModel.ToponimoAgenzia;
                inputModel.IndirizzoAgenzia = aziendaViewModel.IndirizzoAgenzia;
                inputModel.CivicoAgenzia = aziendaViewModel.CivicoAgenzia;
                inputModel.LetteraAgenzia = aziendaViewModel.LetteraAgenzia;
                inputModel.LocalitaAgenzia = aziendaViewModel.LocalitaAgenzia;
                ComuneViewModel comune = await comuneService.GetCodiceCatastaleComuneAsync(aziendaViewModel.CittaAgenzia.CodiceCatastale);
                inputModel.CittaAgenzia = comune.NomeComune;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyIndirizzoAgenzia(AziendaModifyIndirizzoAgenziaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria - Agenzia locale";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyIndirizzoAgenziaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="One"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyTelefonoFaxAgenzia()
        {
            ViewBag.Title = "Azienda condessionaria - Agenzia locale";
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyTelefonoFaxAgenziaInputModel();
                inputModel.TelefonoAgenzia = aziendaViewModel.TelefonoAgenzia;
                inputModel.FaxAgenzia = aziendaViewModel.FaxAgenzia;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyTelefonoFaxAgenzia(AziendaModifyTelefonoFaxAgenziaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria - Agenzia locale";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyTelefonoFaxAgenziaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="One"});
            }
            return View(inputModel);
        }

        public async Task<IActionResult> ModifyEmailPecAgenzia()
        {
            ViewBag.Title = "Azienda condessionaria - Agenzia locale";
            AziendaViewModel aziendaViewModel = await aziendaService.GetAziendaAsync();
            if(aziendaViewModel!=null) 
            {
                var inputModel = new AziendaModifyEmailPecAgenziaInputModel();
                inputModel.EmailAgenzia = aziendaViewModel.EmailAgenzia;
                inputModel.PecAgenzia = aziendaViewModel.PecAgenzia;
                return View(inputModel);
            }
            else return RedirectToAction(nameof(Dettaglio));
        }

        [HttpPost]
        public async Task<IActionResult> ModifyemailPecAgenzia(AziendaModifyEmailPecAgenziaInputModel inputModel)
        {
            ViewBag.Title = "Azienda concessionaria - Agenzia locale";
            if (ModelState.IsValid)
            {
                AziendaViewModel azienda = await aziendaService.ModifyEmailPecAgenziaAsync(inputModel);
                return RedirectToAction("Dettaglio", new {card="One"});
            }
            return View(inputModel);
        }
    }
}