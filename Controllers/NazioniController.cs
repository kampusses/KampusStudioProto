using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class NazioniController : Controller
    {
        private readonly INazioneService nazioneService;
        public NazioniController(INazioneService nazioneService)
        {
            this.nazioneService = nazioneService;
        }
        public async Task<IActionResult> Index(NazioneListInputModel input)
        {
            ListViewModel<NazioneViewModel> nazioni = await nazioneService.GetNazioniAsync(input);
            ViewBag.Title = "Sati esteri";
            NazioneListViewModel viewModel = new NazioneListViewModel
            {
                Nazioni = nazioni,
                Input = input
            };
            return View(viewModel);
        }

        public async Task <IActionResult> Dettaglio(string id)
        {
            NazioneViewModel nazione = await nazioneService.GetNazioneAsync(id);
            ViewBag.Title = "Stato: " + nazione.DenominazioneIT;
            return View(nazione);
        }
    }
}