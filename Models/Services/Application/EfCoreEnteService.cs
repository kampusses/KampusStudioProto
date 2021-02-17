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
        private readonly IConfiguration configuration;
        public EfCoreEnteService(MyDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        async Task<EnteViewModel> IEnteService.GetEnteAsync()
        {
            if(dbContext.Enti.Count() != 0)
            {
            EnteViewModel viewModel = await dbContext.Enti
                .AsNoTracking() // da usare solo per operazioni di sola lettura
                .Select(ente => new EnteViewModel
                {
                    CodiceCatastale = ente.CodiceCatastale,
                    Comune = new ComuneViewModel {
                        CodiceCatastale = ente.Comune.CodiceCatastale,
                        NomeComune = ente.Comune.NomeComune,
                        Provincia = new ProvinciaViewModel {
                            CodiceProvincia = ente.Comune.Provincia.CodiceProvincia,
                            Regione = null,
                            NomeProvincia = ente.Comune.Provincia.NomeProvincia,
                            SiglaProvincia = ente.Comune.Provincia.SiglaProvincia,
                            NComuni = 0,
                            Abitanti = 0
                        },
                        Cap = ente.Comune.Cap
                    },
                    PartitaIva = ente.PartitaIva,
                    CodiceFiscale = ente.CodiceFiscale,
                    Toponimo = ente.Toponimo,
                    Indirizzo = ente.Indirizzo,
                    Civico = ente.Civico,
                    Lettera = ente.Lettera,
                    Localita = ente.Localita,
                    Telefono = ente.Telefono,
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
                EnteViewModel viewModel = new EnteViewModel
                {
                    CodiceCatastale = ""
                };
                return viewModel;
            }
        }
    }
}