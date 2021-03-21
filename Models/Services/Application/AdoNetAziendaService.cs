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
        private readonly IComuneService comuneService;
        public AdoNetAziendaService(IDatabaseAccessor db, IComuneService comuneService)
        {
            this.db = db;
            this.comuneService = comuneService;
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
                ComuneViewModel comuneViewModel = await comuneService.GetCodiceCatastaleComuneAsync(aziendaViewModel.CodiceCatastaleCittaAzienda);
                aziendaViewModel.CittaAzienda = comuneViewModel;
                comuneViewModel = await comuneService.GetCodiceCatastaleComuneAsync(aziendaViewModel.CodiceCatastaleCittaAgenzia);
                aziendaViewModel.CittaAgenzia = comuneViewModel;
            }
            else aziendaViewModel = null;
            return aziendaViewModel;
        }

        public async Task<AziendaViewModel> CreateAziendaAsync(AziendaCreateInputModel inputModel)
        {
            var aziendaEsistente = await GetAziendaAsync();
            if (aziendaEsistente == null)
            {
                var dataSet = await db.QueryAsync($@"INSERT INTO Azienda (nomeAzienda) VALUE ({inputModel.Azienda})");
                var aziendaViewModel = await GetAziendaAsync();
                return aziendaViewModel;
            }
            else throw new InvalidOperationException($"ATTENZIONE! Qualcuno ha già configurato l'azienda");
        }

        public async Task<AziendaViewModel> ModifyNomeAziendaAsync(AziendaModifyNomeAziendaInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET nomeAzienda={inputModel.NomeAzienda}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyIndirizzoAziendaAsync(AziendaModifyIndirizzoAziendaInputModel inputModel)
        {
            ComuneViewModel comune = await comuneService.GetNomeComuneAsync(inputModel.CittaAzienda);
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET toponimoAzienda={inputModel.ToponimoAzienda}, indirizzoAzienda={inputModel.IndirizzoAzienda}, civicoAzienda={inputModel.CivicoAzienda}, letteraAzienda={inputModel.LetteraAzienda}, localitaAzienda={inputModel.LocalitaAzienda}, cittaAzienda={comune.CodiceCatastale}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyCfPivaAziendaAsync(AziendaModifyCfPivaAziendaInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET codiceFiscaleAzienda={inputModel.CodiceFiscaleAzienda}, partitaIvaAzienda={inputModel.PartitaIvaAzienda}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyTelefonoFaxAziendaAsync(AziendaModifyTelefonoFaxAziendaInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET telefonoAzienda={inputModel.TelefonoAzienda}, faxAzienda={inputModel.FaxAzienda}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyEmailPecAziendaAsync(AziendaModifyEmailPecAziendaInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET emailAzienda={inputModel.EmailAzienda}, pecAzienda={inputModel.PecAzienda}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyIndirizzoAgenziaAsync(AziendaModifyIndirizzoAgenziaInputModel inputModel)
        {
            ComuneViewModel comune = await comuneService.GetNomeComuneAsync(inputModel.CittaAgenzia);
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET toponimoAgenzia={inputModel.ToponimoAgenzia}, indirizzoAgenzia={inputModel.IndirizzoAgenzia}, civicoAgenzia={inputModel.CivicoAgenzia}, letteraAgenzia={inputModel.LetteraAgenzia}, localitaAgenzia={inputModel.LocalitaAgenzia}, cittaAgenzia={comune.CodiceCatastale}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyTelefonoFaxAgenziaAsync(AziendaModifyTelefonoFaxAgenziaInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET telefonoAgenzia={inputModel.TelefonoAgenzia}, faxAgenzia={inputModel.FaxAgenzia}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }

        public async Task<AziendaViewModel> ModifyEmailPecAgenziaAsync(AziendaModifyEmailPecAgenziaInputModel inputModel)
        {
            DataSet dataSet = await db.QueryAsync($"UPDATE Azienda SET emailAgenzia={inputModel.EmailAgenzia}, pecAgenzia={inputModel.PecAgenzia}");
            AziendaViewModel azienda = await GetAziendaAsync();
            return azienda;
        }
    }
}