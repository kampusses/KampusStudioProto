using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KampusStudioProto.Models.Services.Application
{
    public class EfCoreComuneService : IComuneService
    {
        private readonly MyDbContext dbContext;
        public EfCoreComuneService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        async Task<ComuneViewModel> IComuneService.GetComuneAsync(string id)
        {
            ComuneViewModel viewModel = await dbContext.Comuni
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

        async Task<List<ComuneViewModel>> IComuneService.GetComuniAsync()
        {
            IQueryable<ComuneViewModel> queryLinq = dbContext.Comuni.Select(comune =>
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
            
            List<ComuneViewModel> comuni = await queryLinq.ToListAsync();
            return comuni;
        }
    }
}