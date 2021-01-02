using System.Collections.Generic;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            var comuneService = new ComuneService();
            List<ComuneViewModel> comuni = comuneService.GetComuni();
            return View(comuni);
        }

        public IActionResult Dettaglio(string id)
        {
            return View();
        }
    }
}