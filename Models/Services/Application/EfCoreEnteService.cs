using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudioProto.Models.Entities;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;
using KampusStudioProto.Customizations.Const;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Models.Services.Application
{
    public class EfCoreEnteService : IEnteService
    {
        private readonly MyDbContext dbContext;
        private readonly IComuneService comuneService;
        public EfCoreEnteService(MyDbContext dbContext, IComuneService comuneService)
        {
            this.dbContext = dbContext;
            this.comuneService = comuneService;
        }

        public async Task<EnteViewModel> GetEnteAsync()
        {
            if(dbContext.Enti.Count() != 0)
            {
            EnteViewModel viewModel = await dbContext.Enti
                .AsNoTracking() // da usare solo per operazioni di sola lettura
                .Select(ente => new EnteViewModel
                {
                    CodiceCatastale = ente.CodiceCatastale,
                    Comune = new ComuneViewModel {
                        NomeComune = ente.Comune.NomeComune,
                        Provincia = new ProvinciaViewModel {
                            SiglaProvincia = ente.Comune.Provincia.SiglaProvincia
                        }
                    }, 
                    PartitaIva = ente.PartitaIva,
                    CodiceFiscale = ente.CodiceFiscale,
                    Toponimo = ente.Toponimo,
                    Indirizzo = ente.Indirizzo,
                    Civico = ente.Civico,
                    Lettera = ente.Lettera,
                    Localita = ente.Localita,
                    Telefono = ente.Telefono,
                    Fax = ente.Fax,
                    Email = ente.Email,
                    Pec = ente.Pec,
                    TitoloResponsabile = ente.TitoloResponsabile,
                    CognomeResponsabile = ente.CognomeResponsabile,
                    NomeResponsabile = ente.NomeResponsabile
                })
                .SingleAsync();
                return viewModel;
            }
            else
            {
                EnteViewModel viewModel = new EnteViewModel();
                viewModel = null;
                return viewModel;
            }
        }

        public async Task<EnteViewModel> CreateEnteAsync(EnteCreateInputModel inputModel)
        {
            var enteEsistente = await GetEnteAsync();
            if (enteEsistente == null)
            {
                string nomeComune = inputModel.Comune;
                ComuneViewModel codiceCatastale = await comuneService.GetNomeComuneAsync(nomeComune);
                var ente = new Ente(codiceCatastale.CodiceCatastale);
                dbContext.Add(ente);
                await dbContext.SaveChangesAsync();
                var enteViewModel = new EnteViewModel();
                enteViewModel.CodiceCatastale = ente.CodiceCatastale;
                return enteViewModel;
            }
            else throw new InvalidOperationException($"ATTENZIONE! Qualcuno ha già configurato un Ente");
        }

        public async Task<EnteViewModel> ModifyEnteAsync(EnteModifySedeLegaleInputModel inputModel)
        {
            var ente = new EnteViewModel();
            ente = await GetEnteAsync();
            return ente;
        }

        public async Task<EnteViewModel> ModifyEnteAsync(EnteModifyDatiFiscaliInputModel inputModel)
        {
            var ente = new EnteViewModel();
            ente = await GetEnteAsync();
            return ente;
        }

        public async Task<EnteViewModel> ModifyEnteAsync(EnteModifyContattiInputModel inputModel)
        {
            var ente = new EnteViewModel();
            ente = await GetEnteAsync();
            return ente;
        }

        public async Task<EnteViewModel> ModifyEnteAsync(EnteModifyResponsabileInputModel inputModel)
        {
            var ente = new EnteViewModel();
            ente = await GetEnteAsync();
            return ente;
        }
    }
}