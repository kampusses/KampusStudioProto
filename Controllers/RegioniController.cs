using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class RegioniController : Controller
    {
        private readonly IRegioneService regioneService;
        public RegioniController(IRegioneService regioneService)
        {
            this.regioneService = regioneService;
        }
        public async Task<IActionResult> Index()
        {
            List<RegioneViewModel> regioni = await regioneService.GetRegioniAsync();
            ViewBag.Titolo = "Regioni Italiane";
            return View(regioni);
        }

        public async Task <IActionResult> Dettaglio(int id)
        {
            RegioneViewModel regione = await regioneService.GetRegioneAsync(id);
            ViewBag.Titolo = "Regione " + regione.NomeRegione;
            return View(regione);
        }
    }
}