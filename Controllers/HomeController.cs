using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel home = await homeService.GetParametriGestioneAsync();
            ViewBag.Title = "Kampus Studio - Ver. Proto";
            return View(home);
        }
    }
}