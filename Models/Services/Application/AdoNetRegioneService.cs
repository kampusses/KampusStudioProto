using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public class AdoNetRegioneService : IRegioneService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetRegioneService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<RegioneViewModel> GetRegioneAsync(int id)
        {
            FormattableString query = $"SELECT * FROM regioni WHERE codiceRegione={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var regioneTable = dataSet.Tables[0];
            if (regioneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var regioneRow = regioneTable.Rows[0];
            var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);

            FormattableString queryReg = $"SELECT * FROM comuni WHERE codiceCatastale={regioneRow["codiceCapoluogo"]}; SELECT abitanti FROM Comuni WHERE codiceRegione={regioneRow["codiceRegione"]}";
            DataSet dataSetCom = await db.QueryAsync(queryReg);
            var comuneTable = dataSetCom.Tables[0];
            if (comuneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {regioneRow["regione"]}");
            }
            var comuneRow = comuneTable.Rows[0];
            var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
            regioneViewModel.Capoluogo = (ComuneViewModel) comuneViewModel;
            regioneViewModel.NComuni = dataSetCom.Tables[1].Rows.Count;
            int abitanti = 0;
            foreach(DataRow riga in dataSetCom.Tables[1].Rows)
            {
                abitanti = abitanti + (int) riga["Abitanti"];
            }
            regioneViewModel.Abitanti = abitanti;

            FormattableString queryPro = $"SELECT * FROM province WHERE codiceRegione={regioneRow["codiceRegione"]} ORDER BY nomeProvincia";
            DataSet dataSetPro = await db.QueryAsync(queryPro);
            var provinciaTable = dataSetPro.Tables[0];
            if (provinciaTable.Rows.Count < 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita almeno una riga della tabella {regioneRow["regione"]}");
            }
            var provinciaList = new List<ProvinciaViewModel>();
            foreach(DataRow proviciaRow in provinciaTable.Rows)
            {
                var provinciaViewModel = ProvinciaViewModel.FromDataRow(proviciaRow);
                provinciaList.Add(provinciaViewModel);
            }
            regioneViewModel.Province = provinciaList;
            return regioneViewModel;
        }

        public async Task<List<RegioneViewModel>> GetRegioniAsync()
        {
            FormattableString query = $"SELECT * FROM Regioni ORDER BY nomeRegione";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var regioneList = new List<RegioneViewModel>();
            foreach(DataRow regioneRow in dataTable.Rows)
            {
                RegioneViewModel regione = RegioneViewModel.FromDataRow(regioneRow);
                FormattableString queryCom = $"SELECT * FROM Comuni WHERE codiceCatastale={regioneRow["codiceCapoluogo"]}; SELECT abitanti FROM Comuni WHERE codiceRegione={regioneRow["codiceRegione"]}";
                DataSet dataSetCom = await db.QueryAsync(queryCom);
                var comuneTable = dataSetCom.Tables[0];
                if (comuneTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {regioneRow["regione"]}");
                }
                var comuneRow = comuneTable.Rows[0];
                var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
                regione.Capoluogo = (ComuneViewModel) comuneViewModel;
                regione.NComuni = dataSetCom.Tables[1].Rows.Count;
                int abitanti = 0;
                foreach(DataRow riga in dataSetCom.Tables[1].Rows)
                {
                    abitanti = abitanti + (int) riga["Abitanti"];
                }
                regione.Abitanti = abitanti;
                regioneList.Add(regione);
            }
            return regioneList;
        }
    }
}