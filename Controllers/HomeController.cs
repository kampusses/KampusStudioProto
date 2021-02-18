using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnteService enteService;
        public HomeController(IEnteService enteService)
        {
            this.enteService = enteService;
        }
        public async Task<IActionResult> Index()
        {
            EnteViewModel ente = await enteService.GetEnteAsync();
            ViewBag.Title = "Kampus Studio - Ver. Proto";
            return View(ente);
        }
    }
}