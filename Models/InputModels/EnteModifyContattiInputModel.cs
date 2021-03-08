using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyContattiInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Telefono"), Phone(ErrorMessage="Inserire il numero di telefono nel seguente formato: +39 0883 656565. Il prefisso internazionale è opzionale")]
        public string Telefono {get; set;}
        [Display(Name="Fax"), Phone(ErrorMessage="Inserire il numero di fax nel seguente formato: +39 0883 656565. Il prefisso internazionale è opzionale")]
        public string Fax {get; set;}
        [Display(Name="Email"), EmailAddress(ErrorMessage="Email non formalmente corretta.")]
        public string Email {get; set;}
        [Display(Name="Pec"), EmailAddress(ErrorMessage="Pec non formalmente corretta.")]
        public string Pec {get; set;}
    }
}