using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KampusStudioProto.Models.Services.Infrastructure;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public class AdoNetProvinciaService : IProvinciaService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetProvinciaService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<ProvinciaViewModel> GetProvinciaAsync(int id)
        {
            FormattableString query = $"SELECT * FROM province WHERE codiceProvincia={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var provinciaTable = dataSet.Tables[0];
            if (provinciaTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var provinciaRow = provinciaTable.Rows[0];
            var provinciaViewModel = ProvinciaViewModel.FromDataRow(provinciaRow);

            FormattableString queryReg = $"SELECT * FROM regioni WHERE codiceRegione={provinciaRow["codiceRegione"]}";
            DataSet dataSetReg = await db.QueryAsync(queryReg);
            var regioneTable = dataSetReg.Tables[0];
            if (regioneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {provinciaRow["regione"]}");
            }
            var regioneRow = regioneTable.Rows[0];
            var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
            provinciaViewModel.Regione = (RegioneViewModel) regioneViewModel;




            FormattableString queryCom = $"SELECT * FROM comuni WHERE codiceProvincia={provinciaRow["codiceProvincia"]}; SELECT abitanti FROM Comuni WHERE codiceProvincia={provinciaRow["codiceProvincia"]}";
            DataSet dataSetCom = await db.QueryAsync(queryCom);
            var comuneTable = dataSetCom.Tables[0];
            if (comuneTable.Rows.Count < 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita almeno una riga della tabella {provinciaRow["regione"]}");
            }
            var comuneRow = comuneTable.Rows[0];
            var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
            provinciaViewModel.NComuni = dataSetCom.Tables[1].Rows.Count;
            int abitanti = 0;
            foreach(DataRow riga in dataSetCom.Tables[1].Rows)
            {
                abitanti = abitanti + (int) riga["Abitanti"];
            }
            provinciaViewModel.Abitanti = abitanti;




            return provinciaViewModel;
        }

        public async Task<List<ProvinciaViewModel>> GetProvinceAsync()
        {
            FormattableString query = $"SELECT * FROM Province ORDER BY nomeProvincia";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var provinciaList = new List<ProvinciaViewModel>();
            foreach(DataRow provinciaRow in dataTable.Rows)
            {
                ProvinciaViewModel provincia = ProvinciaViewModel.FromDataRow(provinciaRow);
                FormattableString queryReg = $"SELECT * FROM Regioni WHERE codiceRegione={provinciaRow["codiceRegione"]}";
                DataSet dataSetReg = await db.QueryAsync(queryReg);
                var regioneTable = dataSetReg.Tables[0];
                if (regioneTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {provinciaRow["regione"]}");
                }
                var regioneRow = regioneTable.Rows[0];
                var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
                provincia.Regione = (RegioneViewModel) regioneViewModel;

                FormattableString queryCom = $"SELECT * FROM comuni WHERE codiceProvincia={provinciaRow["codiceProvincia"]}; SELECT abitanti FROM Comuni WHERE codiceProvincia={provinciaRow["codiceProvincia"]}";
                DataSet dataSetCom = await db.QueryAsync(queryCom);
                var comuneTable = dataSetCom.Tables[0];
                if (comuneTable.Rows.Count < 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita almeno una riga della tabella {regioneRow["regione"]}");
                }
                var comuneRow = comuneTable.Rows[0];
                var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
                provincia.NComuni = dataSetCom.Tables[1].Rows.Count;
                int abitanti = 0;
                foreach(DataRow riga in dataSetCom.Tables[1].Rows)
                {
                    abitanti = abitanti + (int) riga["Abitanti"];
                }
                provincia.Abitanti = abitanti;

                provinciaList.Add(provincia);
            }
            return provinciaList;
        }
    }
}