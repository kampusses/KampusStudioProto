using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudioProto.Models.InputModels;
using KampusStudioProto.Models.ViewModels;

namespace KampusStudioProto.Models.Services.Application
{
    public interface IEnteService
    {
        Task<EnteViewModel> GetEnteAsync();
        Task<EnteViewModel> CreateEnteAsync(EnteCreateInputModel inputModel);
        Task<EnteViewModel> ModifyEnteAsync(EnteModifySedeLegaleInputModel inputModel);
        Task<EnteViewModel> ModifyEnteAsync(EnteModifyDatiFiscaliInputModel inputModel);
        Task<EnteViewModel> ModifyEnteAsync(EnteModifyContattiInputModel inputModel);
        Task<EnteViewModel> ModifyEnteAsync(EnteModifyResponsabileInputModel inputModel);
    }
}