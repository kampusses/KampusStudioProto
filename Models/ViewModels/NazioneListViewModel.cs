using System.Collections.Generic;
using KampusStudioProto.Models.InputModels;

namespace KampusStudioProto.Models.ViewModels
{
    public class NazioneListViewModel : IPaginationInfo
    {
        public ListViewModel<NazioneViewModel> Nazioni {get; set;}
        public NazioneListInputModel Input {get; set;}

        int IPaginationInfo.CurrentPage => Input.Page;
        int IPaginationInfo.TotalResults => Nazioni.TotalCount;
        int IPaginationInfo.ResultsPerPage => Input.Limit;
        string IPaginationInfo.Search => Input.Search;
        string IPaginationInfo.SearchType => Input.SearchType;
        string IPaginationInfo.OrderBy => Input.OrderBy;
        bool IPaginationInfo.Ascending => Input.Ascending;
    }
}