using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IComuneService
    {
         Task<List<ComuneViewModel>> GetComuniAsync();
         Task<ComuneViewModel> GetComuneAsync(string id);
    }
}