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
        public ComuneListInputModel(string search, string searchtype, int page, string orderby, bool ascending, string cap, string prefisso, string belfiore, int provincia, int regione, IConfiguration configuration)
        {
            //sanitizzazione
            if (search == null) Search = "";
            else Search = search;
            if (searchtype == null || (searchtype != "Nome comune" && searchtype != "CAP" && searchtype != "Prefisso" && searchtype != "Belfiore")) SearchType = "Nome comune";
            else SearchType = searchtype;
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
            Cap = cap;
            Prefisso = prefisso;
            Belfiore = belfiore;
            Provincia = provincia;
            Regione = regione;
        }
        public string Search {get;}
        public string SearchType { get; }
        public int Page {get;}
        public string OrderBy {get;}
        public bool Ascending {get;}
        public string Cap { get; }
        public string Prefisso { get; }
        public string Belfiore { get; }
        public int Provincia { get; }
        public int Regione { get; }
        public int Limit {get;}
        public int Offset {get;}
    }
}