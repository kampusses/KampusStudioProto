using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface INazioneService
    {
         Task<List<NazioneViewModel>> GetNazioniAsync();
         Task<NazioneViewModel> GetNazioneAsync(string id);
    }
}