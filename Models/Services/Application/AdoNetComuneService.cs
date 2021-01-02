using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public class AdoNetComuneService : IComuneService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetComuneService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<ComuneViewModel> GetComuneAsync(string id)
        {
            FormattableString query = $"SELECT * FROM comuni WHERE codiceCatastale={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var comuneTable = dataSet.Tables[0];
            if (comuneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var comuneRow = comuneTable.Rows[0];
            var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);

            FormattableString queryReg = $"SELECT * FROM regioni WHERE codiceRegione={comuneRow["codiceRegione"]}";
            DataSet dataSetReg = await db.QueryAsync(queryReg);
            var regioneTable = dataSetReg.Tables[0];
            if (regioneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["regione"]}");
            }
            var regioneRow = regioneTable.Rows[0];
            var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
            comuneViewModel.Regione = (RegioneViewModel) regioneViewModel;

            FormattableString queryPro = $"SELECT * FROM province WHERE codiceProvincia={comuneRow["codiceProvincia"]}";
            DataSet dataSetPro = await db.QueryAsync(queryPro);
            var provinciaTable = dataSetPro.Tables[0];
            if (provinciaTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["provincia"]}");
            }
            var provinciaRow = provinciaTable.Rows[0];
            var provinciaViewModel = ProvinciaViewModel.FromDataRow(provinciaRow);
            comuneViewModel.Provincia = (ProvinciaViewModel) provinciaViewModel;

            return comuneViewModel;
        }

        public async Task<List<ComuneViewModel>> GetComuniAsync()
        {
            FormattableString query = $"SELECT * FROM Comuni WHERE nomeComune LIKE '%Bar%'";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var comuneList = new List<ComuneViewModel>();
            foreach(DataRow comuneRow in dataTable.Rows)
            {
                ComuneViewModel comune = ComuneViewModel.FromDataRow(comuneRow);
                FormattableString queryReg = $"SELECT * FROM Regioni WHERE codiceRegione={comuneRow["codiceRegione"]}";
                DataSet dataSetReg = await db.QueryAsync(queryReg);
                var regioneTable = dataSetReg.Tables[0];
                if (regioneTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["regione"]}");
                }
                var regioneRow = regioneTable.Rows[0];
                var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
                comune.Regione = (RegioneViewModel) regioneViewModel;

                FormattableString queryPro = $"SELECT * FROM Province WHERE codiceProvincia={comuneRow["codiceProvincia"]}";
                DataSet dataSetPro = await db.QueryAsync(queryPro);
                var provinciaTable = dataSetPro.Tables[0];
                if (provinciaTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["provincia"]}");
                }
                var provinciaRow = provinciaTable.Rows[0];
                var provinciaViewModel = ProvinciaViewModel.FromDataRow(provinciaRow);
                comune.Provincia = (ProvinciaViewModel) provinciaViewModel;

                comuneList.Add(comune);
            }
            return comuneList;
        }
    }
}