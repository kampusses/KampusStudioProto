using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public class AdoNetNazioneService : INazioneService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetNazioneService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<NazioneViewModel> GetNazioneAsync(string id)
        {
            FormattableString query = $"SELECT * FROM nazioni WHERE codice3={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var nazioneTable = dataSet.Tables[0];
            if (nazioneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var nazioneRow = nazioneTable.Rows[0];
            var nazioneViewModel = NazioneViewModel.FromDataRow(nazioneRow);
            return nazioneViewModel;
        }

        public async Task<ListViewModel<NazioneViewModel>> GetNazioniAsync(NazioneListInputModel model)
        {
            FormattableString query = $@"SELECT * FROM Nazioni ORDER BY denominazioneIT LIMIT {model.Limit} OFFSET {model.Offset};
            SELECT COUNT(*) FROM Nazioni";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var nazioneList = new List<NazioneViewModel>();
            foreach(DataRow nazioneRow in dataTable.Rows)
            {
                NazioneViewModel nazione = NazioneViewModel.FromDataRow(nazioneRow);
                nazioneList.Add(nazione);
            }

            ListViewModel<NazioneViewModel> result = new ListViewModel<NazioneViewModel>
            {
                Results = nazioneList,
                TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
            };

            return result;
        }
    }
}