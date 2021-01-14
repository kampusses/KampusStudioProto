using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IComuneService
    {
         Task<List<ComuneViewModel>> GetComuniAsync(ComuneListInputModel model);
         Task<ComuneViewModel> GetComuneAsync(string id);
    }
}