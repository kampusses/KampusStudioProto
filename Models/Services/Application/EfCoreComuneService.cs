using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudioProto.Models.Entities;
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

        async Task<List<ComuneViewModel>> IComuneService.GetComuniAsync(string search, int page, string orderby, bool ascending)
        {
            if (search == null) search = "";
            if (orderby == null) orderby = "";
            page = Math.Max(1, page);
            int limit = configuration.GetSection("Comuni").GetValue<int>("PerPage");
            int offset = (page - 1) * limit;

            IConfigurationSection parametriOrdinamento = configuration.GetSection("Comuni").GetSection("Order");
            if (orderby.ToLower() != "nomecomune" & orderby.ToLower() != "abitanti")
            {
                orderby = parametriOrdinamento.GetValue<string>("By");
                ascending = parametriOrdinamento.GetValue<bool>("Ascending");
            }

            IQueryable<Comune> baseQuery = dbContext.Comuni;
            if (orderby.ToLower() == "nomecomune")
            {
                if (ascending) baseQuery = baseQuery.OrderBy(comune => comune.NomeComune);
                else baseQuery = baseQuery.OrderByDescending(comune => comune.NomeComune);
                
            }
            else
            {
                if (ascending) baseQuery = baseQuery.OrderBy(comune => comune.Abitanti);
                else baseQuery = baseQuery.OrderByDescending(comune => comune.Abitanti);
            }

            IQueryable<ComuneViewModel> queryLinq = baseQuery
            .Skip(offset)
            .Take(limit)
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
            })
            .Where(comune => comune.NomeComune.Contains(search));
            List<ComuneViewModel> comuni = await queryLinq.ToListAsync();
            return comuni;
        }
    }
}