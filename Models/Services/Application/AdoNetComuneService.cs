using System;
using System.Collections.Generic;
using System.Data;
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
        public ComuneViewModel GetComune(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<ComuneViewModel> GetComuni()
        {
            string query = "SELECT * FROM Comuni WHERE nomeComune LIKE '%Bar%'";
            DataSet dataSet = db.Query(query);
            var dataTable = dataSet.Tables[0];
            var comuneList = new List<ComuneViewModel>();
            foreach(DataRow comuneRow in dataTable.Rows)
            {
                ComuneViewModel comune = ComuneViewModel.FromDataRow(comuneRow);
                String queryReg = $"SELECT * FROM Regioni WHERE codiceRegione={comuneRow["codiceRegione"]}";
                DataSet dataSetReg = db.Query(queryReg);
                var regioneTable = dataSetReg.Tables[0];
                if (regioneTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["regione"]}");
                }
                var regioneRow = regioneTable.Rows[0];
                var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
                comune.Regione = (RegioneViewModel) regioneViewModel;

                String queryPro = $"SELECT * FROM Province WHERE codiceProvincia={comuneRow["codiceProvincia"]}";
                DataSet dataSetPro = db.Query(queryPro);
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