using System.Collections.Generic;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IComuneService
    {
         List<ComuneViewModel> GetComuni();
         ComuneViewModel GetComune(string id);
    }
}