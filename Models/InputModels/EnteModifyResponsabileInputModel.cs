using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyResponsabileInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Titolo funzionario")]
        public string TitoloResponsabile {get; set;}
        [Display(Name="Cognome funzionario")]
        public string CognomeResponsabile {get; set;}
        [Display(Name="Nome funzionario")]
        public string NomeResponsabile {get; set;}
    }
}