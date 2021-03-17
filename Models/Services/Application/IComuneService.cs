using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IComuneService
    {
         Task<ListViewModel<ComuneViewModel>> GetComuniAsync(ComuneListInputModel model);
         Task<ComuneViewModel> GetComuneAsync(string id);
         Task<ComuneViewModel> GetNomeComuneAsync(string nomeComune);
         Task<ComuneViewModel> GetCodiceCatastaleComuneAsync(string codiceCatastaleComune);
    }
}