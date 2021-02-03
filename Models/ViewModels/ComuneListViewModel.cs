using System.Collections.Generic;
using KampusStudioProto.Models.InputModels;

namespace KampusStudioProto.Models.ViewModels
{
    public class ComuneListViewModel : IPaginationInfo
    {
        public ListViewModel<ComuneViewModel> Comuni {get; set;}
        public ComuneListInputModel Input {get; set;}

        int IPaginationInfo.CurrentPage => Input.Page;
        int IPaginationInfo.TotalResults => Comuni.TotalCount;
        int IPaginationInfo.ResultsPerPage => Input.Limit;
        string IPaginationInfo.Search => Input.Search;
        string IPaginationInfo.SearchType => Input.SearchType;
        string IPaginationInfo.OrderBy => Input.OrderBy;
        bool IPaginationInfo.Ascending => Input.Ascending;
        string IPaginationInfo.Cap => Input.Cap;
        string IPaginationInfo.Prefisso => Input.Prefisso;
        string IPaginationInfo.Belfiore => Input.Belfiore;
        int IPaginationInfo.Provincia => Input.Provincia;
    }
}