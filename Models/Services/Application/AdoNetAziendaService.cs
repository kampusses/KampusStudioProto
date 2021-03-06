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
    public class AdoNetAziendaService : IAziendaService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetAziendaService(IDatabaseAccessor db)
        {
            this.db = db;
        }
    
        public async Task<AziendaViewModel> GetAziendaAsync()
        {
            FormattableString query = $"SELECT * FROM azienda";
            DataSet dataSet = await db.QueryAsync(query);
            var aziendaTable = dataSet.Tables[0];
            var aziendaViewModel = new AziendaViewModel();
            if (aziendaTable.Rows.Count != 0)
            {
                var aziendaRow = aziendaTable.Rows[0];
                aziendaViewModel = AziendaViewModel.FromDataRow(aziendaRow);
            }
            else aziendaViewModel = null;
            return aziendaViewModel;
        }
/*
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
        */
    }
}