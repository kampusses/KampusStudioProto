using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IComuneService
    {
         Task<List<ComuneViewModel>> GetComuniAsync(string search, int page, string orderby, bool ascending);
         Task<ComuneViewModel> GetComuneAsync(string id);
    }
}