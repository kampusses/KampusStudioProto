using System;
using KampusStudioProto.Customizations.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Models.InputModels
{
    // usare il model binders personalizzato
    [ModelBinder(BinderType = typeof(ComuneListInputModelBinder))]
    public class ComuneListInputModel
    {
        public ComuneListInputModel(string search, int page, string orderby, bool ascending, IConfiguration configuration)
        {
            //sanitizzazione
            if (search == null) Search = "";
            else Search = search;
            if (orderby == null) orderby = "";
            Page = Math.Max(1, page);
            Limit = configuration.GetSection("Comuni").GetValue<int>("PerPage");
            Offset = (Page - 1) * Limit;
            IConfigurationSection parametriOrdinamento = configuration.GetSection("Comuni").GetSection("Order");
            if (orderby.ToLower() != "nomecomune" & orderby.ToLower() != "abitanti")
            {
                orderby = parametriOrdinamento.GetValue<string>("By");
                ascending = parametriOrdinamento.GetValue<bool>("Ascending");
            }

            OrderBy = orderby;
            Ascending = ascending;
        }
        public string Search {get;}
        public int Page {get;}
        public string OrderBy {get;}
        public bool Ascending {get;}
        public int Limit {get;}
        public int Offset {get;}
    }
}