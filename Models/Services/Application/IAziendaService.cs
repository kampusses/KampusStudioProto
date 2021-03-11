using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IAziendaService
    {
        Task<AziendaViewModel> GetAziendaAsync();
        Task<AziendaViewModel> CreateAziendaAsync(AziendaCreateInputModel inputModel);
        Task<AziendaViewModel> ModifyNomeAziendaAsync(AziendaModifyNomeAziendaInputModel inputModel);
    }
}