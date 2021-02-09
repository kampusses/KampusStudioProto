using System;
using KampusStudioProto.Customizations.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Models.InputModels
{
    // usare il model binders personalizzato
    [ModelBinder(BinderType = typeof(ProvinciaListInputModelBinder))]
    public class ProvinciaListInputModel
    {
        public ProvinciaListInputModel(string search, string searchtype, int page, string orderby, bool ascending, IConfiguration configuration)
        {
            //sanitizzazione
            if (search == null) Search = "";
            else Search = search;
            if (searchtype == null || (searchtype != "Nome provincia" && searchtype != "Regione")) SearchType = "Nome provincia";
            else SearchType = searchtype;
            if (orderby == null) orderby = "";
            Page = Math.Max(1, page);
            Limit = configuration.GetSection("Province").GetValue<int>("PerPage");
            Offset = (Page - 1) * Limit;
            IConfigurationSection parametriOrdinamento = configuration.GetSection("Province").GetSection("Order");
            if (orderby.ToLower() != "nomeprovincia")
            {
                orderby = parametriOrdinamento.GetValue<string>("By");
                ascending = parametriOrdinamento.GetValue<bool>("Ascending");
            }

            OrderBy = orderby;
            Ascending = ascending;
        }
        public string Search {get;}
        public string SearchType { get; }
        public int Page {get;}
        public string OrderBy {get;}
        public bool Ascending {get;}
        public int Limit {get;}
        public int Offset {get;}
    }
}