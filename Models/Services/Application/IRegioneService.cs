using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IRegioneService
    {
         Task<List<RegioneViewModel>> GetRegioniAsync();
         Task<RegioneViewModel> GetRegioneAsync(int id);
    }
}