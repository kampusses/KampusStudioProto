using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IProvinciaService
    {
         Task<ListViewModel<ProvinciaViewModel>> GetProvinceAsync(ProvinciaListInputModel model);
         Task<ProvinciaViewModel> GetProvinciaAsync(int id);
    }
}