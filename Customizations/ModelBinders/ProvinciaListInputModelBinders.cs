using System;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace KampusStudioProto.Customizations.ModelBinders
{
    public class ProvinciaListInputModelBinder : IModelBinder
    {
        private readonly IConfiguration configuration;
        public ProvinciaListInputModelBinder(IConfiguration configuration)
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

            //creiamo l'istanza del ProvinciaListInputmodel
            var inputModel = new ProvinciaListInputModel(search, searchType, page, orderBy, ascending, configuration);
            //impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}