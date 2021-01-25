using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinciaService provinciaService;
        public ProvinceController(IProvinciaService provinciaService)
        {
            this.provinciaService = provinciaService;
        }
        public async Task<IActionResult> Index()
        {
            List<ProvinciaViewModel> province = await provinciaService.GetProvinceAsync();
            ViewBag.Title = "Province italiane";
            return View(province);
        }

        public async Task<IActionResult> Dettaglio(int id)
        {
            ProvinciaViewModel provincia = await provinciaService.GetProvinciaAsync(id);
            ViewBag.Title = "Provincia di " + provincia.NomeProvincia;
            return View(provincia);
        }
    }
}