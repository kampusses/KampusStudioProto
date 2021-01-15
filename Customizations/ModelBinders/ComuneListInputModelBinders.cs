using System;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Customizations.ModelBinders
{
    public class ComuneListInputModelBinder : IModelBinder
    {
        private readonly IConfiguration configuration;
        public ComuneListInputModelBinder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Recuperiamo i valori grazie ai value provider
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string searchType = bindingContext.ValueProvider.GetValue("SearchType").FirstValue;
            int page = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Page").FirstValue);
            string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue;
            bool ascending = Convert.ToBoolean(bindingContext.ValueProvider.GetValue("Ascending").FirstValue);
            string cap = bindingContext.ValueProvider.GetValue("Cap").FirstValue;
            string prefisso = bindingContext.ValueProvider.GetValue("Prefisso").FirstValue;
            string belfiore = bindingContext.ValueProvider.GetValue("Belfiore").FirstValue;

            //creiamo l'istanza del ComuneListInputmodel
            var inputModel = new ComuneListInputModel(search, searchType, page, orderBy, ascending, cap, prefisso, belfiore, configuration);

            //impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}