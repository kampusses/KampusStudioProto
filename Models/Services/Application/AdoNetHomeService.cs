using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using kampus.Models.ValueTypes;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Models.Services.Application
{
    public class AdoNetHomeService : IHomeService
    {
        private readonly IEnteService enteService;
        private readonly IAziendaService aziendaService;
        public AdoNetHomeService(IEnteService enteService, IAziendaService aziendaService)
        {
            this.enteService = enteService;
            this.aziendaService = aziendaService;
        }
    
        public async Task<HomeViewModel> GetParametriGestioneAsync()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.Ente = await enteService.GetEnteAsync();
            homeViewModel.Azienda = await aziendaService.GetAziendaAsync();
            return homeViewModel;
        }
    }
}