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
            string query = "SELECT * FROM Comuni";
            DataSet dataSet = db.Query(query);
            throw new System.NotImplementedException();
        }
    }
}