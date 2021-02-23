using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudioProto.Models.Entities;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Models.Services.Application
{
    public class EfCoreComuneService : IComuneService
    {
        private readonly MyDbContext dbContext;
        private readonly IConfiguration configuration;
        public EfCoreComuneService(MyDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        async Task<ComuneViewModel> IComuneService.GetComuneAsync(string id)
        {
            ComuneViewModel viewModel = await dbContext.Comuni
                .AsNoTracking() // da usare solo per operazioni di sola lettura
                .Where(comune => comune.CodiceCatastale == id)
                .Select(comune => new ComuneViewModel
                {
                    CodiceCatastale = comune.CodiceCatastale,
                    NomeComune = comune.NomeComune,
                    Abitanti = comune.Abitanti,
                    FlagRegione = Convert.ToBoolean(comune.FlagRegione),
                    FlagProvincia = Convert.ToBoolean(comune.FlagProvincia),
                    Regione = new RegioneViewModel {
                        CodiceRegione = comune.Regione.CodiceRegione,
                        NomeRegione = comune.Regione.NomeRegione,
                        RipartizioneGeografica = (RipartizioneGeografica) comune.Regione.RipartizioneGeografica - 1,
                        Capoluogo = null,
                        NComuni = 0,
                        Abitanti = 0,
                        Province = null
                    },
                    Provincia = new ProvinciaViewModel {
                        CodiceProvincia = comune.Provincia.CodiceProvincia,
                        Regione = null,
                        NomeProvincia = comune.Provincia.NomeProvincia,
                        SiglaProvincia = comune.Provincia.SiglaProvincia,
                        NComuni = 0,
                        Abitanti = 0
                    },
                    Cap = comune.Cap,
                    Prefisso = comune.Prefisso,
                    CodiceIstat = comune.CodiceIstat
                })
                .SingleAsync();
                return viewModel;
        }

        public async Task<ComuneViewModel> GetNomeComuneAsync(string nomeComune)
        {
            ComuneViewModel viewModel = await dbContext.Comuni
                .AsNoTracking() // da usare solo per operazioni di sola lettura
                .Where(comune => comune.NomeComune == nomeComune)
                .Select(comune => new ComuneViewModel
                {
                    CodiceCatastale = comune.CodiceCatastale,
                    NomeComune = comune.NomeComune,
                    Abitanti = comune.Abitanti,
                    FlagRegione = Convert.ToBoolean(comune.FlagRegione),
                    FlagProvincia = Convert.ToBoolean(comune.FlagProvincia),
                    Regione = new RegioneViewModel {
                        CodiceRegione = comune.Regione.CodiceRegione,
                        NomeRegione = comune.Regione.NomeRegione,
                        RipartizioneGeografica = (RipartizioneGeografica) comune.Regione.RipartizioneGeografica - 1,
                        Capoluogo = null,
                        NComuni = 0,
                        Abitanti = 0,
                        Province = null
                    },
                    Provincia = new ProvinciaViewModel {
                        CodiceProvincia = comune.Provincia.CodiceProvincia,
                        Regione = null,
                        NomeProvincia = comune.Provincia.NomeProvincia,
                        SiglaProvincia = comune.Provincia.SiglaProvincia,
                        NComuni = 0,
                        Abitanti = 0
                    },
                    Cap = comune.Cap,
                    Prefisso = comune.Prefisso,
                    CodiceIstat = comune.CodiceIstat
                })
                .SingleAsync();
                return viewModel;
        }

        async Task<ListViewModel<ComuneViewModel>> IComuneService.GetComuniAsync(ComuneListInputModel model)
        {
            IQueryable<Comune> baseQuery = dbContext.Comuni;
            if (model.OrderBy.ToLower() == "nomecomune")
            {
                if (model.Ascending) baseQuery = baseQuery.OrderBy(comune => comune.NomeComune);
                else baseQuery = baseQuery.OrderByDescending(comune => comune.NomeComune);
                
            }
            else
            {
                if (model.Ascending) baseQuery = baseQuery.OrderBy(comune => comune.Abitanti);
                else baseQuery = baseQuery.OrderByDescending(comune => comune.Abitanti);
            }

            if (model.SearchType == "Nome comune") 
            baseQuery = baseQuery.Where(comune => comune.NomeComune.Contains(model.Search));
            if (model.SearchType == "CAP") 
            baseQuery = baseQuery.Where(comune => comune.Cap.Contains(model.Search));
            if (model.SearchType == "Prefisso") 
            baseQuery = baseQuery.Where(comune => comune.Prefisso.Contains(model.Search));
            if (model.SearchType == "Belfiore") 
            baseQuery = baseQuery.Where(comune => comune.CodiceCatastale.Contains(model.Search));
            if (model.SearchType == "Provincia")
            baseQuery = baseQuery.Where(comune => comune.CodiceProvincia == Convert.ToInt32(model.Search));
            if (model.SearchType == "Regione")
            baseQuery = baseQuery.Where(comune => comune.CodiceRegione == Convert.ToInt32(model.Search));

            IQueryable<ComuneViewModel> queryLinq = baseQuery
            .AsNoTracking() // da usare solo per operazioni di sola lettura
            .Select(comune =>
            new ComuneViewModel {
                CodiceCatastale = comune.CodiceCatastale,
                NomeComune = comune.NomeComune,
                Abitanti = comune.Abitanti,
                FlagRegione = Convert.ToBoolean(comune.FlagRegione),
                FlagProvincia = Convert.ToBoolean(comune.FlagProvincia),
                Regione = new RegioneViewModel {
                    CodiceRegione = comune.Regione.CodiceRegione,
                    NomeRegione = comune.Regione.NomeRegione,
                    RipartizioneGeografica = (RipartizioneGeografica) comune.Regione.RipartizioneGeografica - 1,
                    Capoluogo = null,
                    NComuni = 0,
                    Abitanti = 0,
                    Province = null
                },
                Provincia = new ProvinciaViewModel {
                    CodiceProvincia = comune.Provincia.CodiceProvincia,
                    Regione = null,
                    NomeProvincia = comune.Provincia.NomeProvincia,
                    SiglaProvincia = comune.Provincia.SiglaProvincia,
                    NComuni = 0,
                    Abitanti = 0
                },
                Cap = comune.Cap,
                Prefisso = comune.Prefisso,
                CodiceIstat = comune.CodiceIstat
            });

            List<ComuneViewModel> comuni = await queryLinq
            .Skip(model.Offset)
            .Take(model.Limit)
            .ToListAsync();

            int totalCount = await queryLinq.CountAsync();

            ListViewModel<ComuneViewModel> result = new ListViewModel<ComuneViewModel>
            {
                Results = comuni,
                TotalCount = totalCount
            };
            return result;
        }
    }
}