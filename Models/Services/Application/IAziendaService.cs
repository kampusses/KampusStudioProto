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
        Task<AziendaViewModel> ModifyIndirizzoAziendaAsync(AziendaModifyIndirizzoAziendaInputModel inputModel);
        Task<AziendaViewModel> ModifyCfPivaAziendaAsync(AziendaModifyCfPivaAziendaInputModel inputModel);
        Task<AziendaViewModel> ModifyTelefonoFaxAziendaAsync(AziendaModifyTelefonoFaxAziendaInputModel inputModel);
        Task<AziendaViewModel> ModifyEmailPecAziendaAsync(AziendaModifyEmailPecAziendaInputModel inputModel);
        Task<AziendaViewModel> ModifyIndirizzoAgenziaAsync(AziendaModifyIndirizzoAgenziaInputModel inputModel);
    }
}