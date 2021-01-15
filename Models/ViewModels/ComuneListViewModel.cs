using System.Collections.Generic;
using KampusStudioProto.Models.InputModels;

namespace KampusStudioProto.Models.ViewModels
{
    public class ComuneListViewModel
    {
        public ListViewModel<ComuneViewModel> Comuni {get; set;}
        public ComuneListInputModel Input {get; set;}
    }
}