using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface INazioneService
    {
         Task<ListViewModel<NazioneViewModel>> GetNazioniAsync(NazioneListInputModel model);
         Task<NazioneViewModel> GetNazioneAsync(string id);
    }
}