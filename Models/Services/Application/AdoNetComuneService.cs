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
    public class AdoNetComuneService : IComuneService
    {
        private readonly IDatabaseAccessor db;
        private readonly IConfiguration configuration;
        public AdoNetComuneService(IDatabaseAccessor db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
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

        public async Task<ListViewModel<ComuneViewModel>> GetComuniAsync(ComuneListInputModel model)
        {
            string direction = model.Ascending ? "ASC" : "DESC";
            FormattableString query = $"";
            if (model.SearchType=="Nome comune")
            {
                query = $@"SELECT * FROM comuni WHERE nomeComune LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"}  AND codiceCatastale LIKE {"%" + model.Belfiore + "%"} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
                SELECT COUNT(*) FROM comuni WHERE nomeComune LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"} AND codiceCatastale LIKE {"%" + model.Belfiore + "%"}";
            }
            
            if (model.SearchType=="CAP")
            {
                query = $@"SELECT * FROM comuni WHERE cap LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"}  AND codiceCatastale LIKE {"%" + model.Belfiore + "%"} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
                SELECT COUNT(*) FROM comuni WHERE cap LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"} AND codiceCatastale LIKE {"%" + model.Belfiore + "%"}";
            }

            if (model.SearchType=="Prefisso")
            {
                query = $@"SELECT * FROM comuni WHERE prefisso LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"}  AND codiceCatastale LIKE {"%" + model.Belfiore + "%"} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
                SELECT COUNT(*) FROM comuni WHERE prefisso LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"} AND codiceCatastale LIKE {"%" + model.Belfiore + "%"}";
            }

            if (model.SearchType=="Belfiore")
            {
                query = $@"SELECT * FROM comuni WHERE codiceCatastale LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"}  AND codiceCatastale LIKE {"%" + model.Belfiore + "%"} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
                SELECT COUNT(*) FROM comuni WHERE prefisso LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"} AND codiceCatastale LIKE {"%" + model.Belfiore + "%"}";
            }
            
            if (model.Provincia != 0)
            {
                query = $@"SELECT * FROM comuni WHERE codiceProvincia = {model.Provincia} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
                SELECT COUNT(*) FROM comuni WHERE codiceProvincia = {model.Provincia}";
            }

            if (model.Regione != 0)
            {
                query = $@"SELECT * FROM comuni WHERE codiceRegione = {model.Regione} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
                SELECT COUNT(*) FROM comuni WHERE codiceRegione = {model.Regione}";
            }

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

            ListViewModel<ComuneViewModel> result = new ListViewModel<ComuneViewModel>
            {
                Results = comuneList,
                TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
            };

            return result;
        }
    }
}