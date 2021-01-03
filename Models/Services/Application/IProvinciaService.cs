using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IProvinciaService
    {
         Task<List<ProvinciaViewModel>> GetProvinceAsync();
         Task<ProvinciaViewModel> GetProvinciaAsync(int id);
    }
}