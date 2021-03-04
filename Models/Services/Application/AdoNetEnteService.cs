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
    public class AdoNetEnteService : IEnteService
    {
        private readonly IDatabaseAccessor db;
        private readonly IComuneService comuneService;
        public AdoNetEnteService(IDatabaseAccessor db, IComuneService comuneService)
        {
            this.db = db;
            this.comuneService = comuneService;
        }
    
        public async Task<EnteViewModel> GetEnteAsync()
        {
            FormattableString query = $"SELECT * FROM ente";
            DataSet dataSet = await db.QueryAsync(query);
            var enteTable = dataSet.Tables[0];
            var enteViewModel = new EnteViewModel();
            if (enteTable.Rows.Count != 0)
            {
                var enteRow = enteTable.Rows[0];
                enteViewModel = EnteViewModel.FromDataRow(enteRow);
                var comuneViewModel = new ComuneViewModel();
                comuneViewModel = await comuneService.GetComuneAsync(enteViewModel.CodiceCatastale);
                enteViewModel.Comune = comuneViewModel;
            }
            else enteViewModel = null;
            return enteViewModel;
        }

        public async Task<EnteViewModel> CreateEnteAsync(EnteCreateInputModel inputModel)
        {
            var enteEsistente = await GetEnteAsync();
            if (enteEsistente == null)
            {
                string nomeComune = inputModel.Comune;
                ComuneViewModel comuneViewModel = await comuneService.GetNomeComuneAsync(nomeComune);
                var dataSet = await db.QueryAsync($@"INSERT INTO Ente (codiceCatastale) VALUE ({comuneViewModel.CodiceCatastale})");
                var enteViewModel = await GetEnteAsync();
                return enteViewModel;
            }
            else throw new InvalidOperationException($"ATTENZIONE! Qualcuno ha già configurato un Ente");
        }

        public async Task<EnteViewModel> ModifyEnteAsync(EnteModifyInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Ente SET Toponimo={inputModel.Toponimo}, Indirizzo={inputModel.Indirizzo}, Civico={inputModel.Civico}, Lettera={inputModel.Lettera}, Localita={inputModel.Localita}, PartitaIva={inputModel.PartitaIva}, CodiceFiscale={inputModel.CodiceFiscale}, Telefono={inputModel.Telefono}, Fax={inputModel.Fax}, Email={inputModel.Email}, Pec={inputModel.Pec}, TitoloResponsabile={inputModel.TitoloResponsabile}, CognomeResponsabile={inputModel.CognomeResponsabile}, NomeResponsabile={inputModel.NomeResponsabile} WHERE codiceCatastale={inputModel.CodiceCatastale}");
            EnteViewModel ente = await GetEnteAsync();
            return ente;
        }
    }
}