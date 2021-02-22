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
    
        async Task<EnteViewModel> IEnteService.GetEnteAsync()
        {
            FormattableString query = $"SELECT * FROM ente";
            DataSet dataSet = await db.QueryAsync(query);
            var enteTable = dataSet.Tables[0];
            var enteViewModel = new EnteViewModel();
            if (enteTable.Rows.Count == 1)
            {
                var enteRow = enteTable.Rows[0];
                enteViewModel = EnteViewModel.FromDataRow(enteRow);
                var comuneViewModel = new ComuneViewModel();
                comuneViewModel = await comuneService.GetComuneAsync(enteViewModel.CodiceCatastale);
                enteViewModel.Comune = comuneViewModel;
            }
            else enteViewModel.CodiceCatastale = "";
            return enteViewModel;
        }

        public Task<EnteViewModel> CreaEnteAsync(EnteCreateInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}