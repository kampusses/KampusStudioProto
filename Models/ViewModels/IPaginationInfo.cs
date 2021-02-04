namespace KampusStudioProto.Models.ViewModels
{
    public interface IPaginationInfo
    
    {
        int CurrentPage {get;}
        int TotalResults {get;}
        int ResultsPerPage {get;}
        string Search {get;}
        string SearchType {get;}
        string OrderBy {get;}
        bool Ascending {get;}
        string Cap {get;}
        string Prefisso {get;}
        string Belfiore {get;}
        int Provincia {get;}
        int Regione {get;}
    }
}