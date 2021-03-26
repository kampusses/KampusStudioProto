using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Application;
using KampusStudioProto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudioProto.Customizations.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly IAziendaService aziendaService;
        private readonly IEnteService enteService;
        public BreadcrumbViewComponent(IAziendaService aziendaService, IEnteService enteService)
        {
            this.aziendaService = aziendaService;
            this.enteService = enteService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeViewModel model = new HomeViewModel();
            model.Azienda = await aziendaService.GetAziendaAsync();
            model.Ente = await enteService.GetEnteAsync();
            return View(model);
        }
    }
}

