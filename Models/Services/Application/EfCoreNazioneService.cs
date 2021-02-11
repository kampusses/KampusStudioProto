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
    public class EfCoreNazioneService : INazioneService
    {
        private readonly MyDbContext dbContext;
        private readonly IConfiguration configuration;
        public EfCoreNazioneService(MyDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        async Task<NazioneViewModel> INazioneService.GetNazioneAsync(string id)
        {
            var NomeContinente = new Continente();
            var NomeArea = new AreaGeo();
            NazioneViewModel viewModel = await dbContext.Nazioni
                .AsNoTracking() // da usare solo per operazioni di sola lettura
                .Where(nazione => nazione.Codice3 == id)
                .Select(nazione => new NazioneViewModel
                {
                    CodiceContinente = Convert.ToInt32(nazione.CodiceContinente),
                    Continente = NomeContinente.GetNomeContinente(nazione.CodiceContinente),
                    CodiceArea = Convert.ToInt32(nazione.CodiceArea),
                    Area = NomeArea.GetNomeArea(nazione.CodiceArea),
                    DenominazioneIT = nazione.DenominazioneIt,
                    DenominazioneEN = nazione.DenominazioneEn,
                    Belfiore = nazione.Belfiore,
                    Codice2 = nazione.Codice2,
                    Codice3 = nazione.Codice3,
                    Codice3Padre = nazione.Codice3Padre
                })
                .SingleAsync();

                return viewModel;
        }

        async Task<ListViewModel<NazioneViewModel>> INazioneService.GetNazioniAsync(NazioneListInputModel model)
        {
            IQueryable<Nazione> baseQuery = dbContext.Nazioni;
            baseQuery = baseQuery.OrderBy(nazione => nazione.DenominazioneIt);
            var NomeContinente = new Continente();
            var NomeArea = new AreaGeo();
            IQueryable<NazioneViewModel> queryLinq = baseQuery
            .AsNoTracking() // da usare solo per operazioni di sola lettura
            .Select(nazione =>
            new NazioneViewModel {
                CodiceContinente = nazione.CodiceContinente,
                Continente = NomeContinente.GetNomeContinente(nazione.CodiceContinente),
                CodiceArea = nazione.CodiceArea,
                Area = NomeArea.GetNomeArea(nazione.CodiceArea),
                DenominazioneIT = nazione.DenominazioneIt,
                DenominazioneEN = nazione.DenominazioneEn,
                Belfiore = nazione.Belfiore,
                Codice2 = nazione.Codice2,
                Codice3 = nazione.Codice3,
                Codice3Padre = nazione.Codice3Padre
            });

            List<NazioneViewModel> nazioni = await queryLinq
            .Skip(model.Offset)
            .Take(model.Limit)
            .ToListAsync();

            int totalCount = await queryLinq.CountAsync();

            ListViewModel<NazioneViewModel> result = new ListViewModel<NazioneViewModel>
            {
                Results = nazioni,
                TotalCount = totalCount
            };
            return result;
        }
    }
}