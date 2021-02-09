using System.Collections.Generic;
using KampusStudioProto.Models.InputModels;

namespace KampusStudioProto.Models.ViewModels
{
    public class ProvinciaListViewModel : IPaginationInfo
    {
        public ListViewModel<ProvinciaViewModel> Province {get; set;}
        public ProvinciaListInputModel Input {get; set;}

        int IPaginationInfo.CurrentPage => Input.Page;
        int IPaginationInfo.TotalResults => Province.TotalCount;
        int IPaginationInfo.ResultsPerPage => Input.Limit;
        string IPaginationInfo.Search => Input.Search;
        string IPaginationInfo.SearchType => Input.SearchType;
        string IPaginationInfo.OrderBy => Input.OrderBy;
        bool IPaginationInfo.Ascending => Input.Ascending;
    }
}