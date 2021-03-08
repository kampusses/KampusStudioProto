using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyResponsabileInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Titolo funzionario")]
        public string TitoloResponsabile {get; set;}
        [Display(Name="Cognome funzionario"), Required(ErrorMessage="L'inserimento del cognome è obbligatorio.")]
        public string CognomeResponsabile {get; set;}
        [Display(Name="Nome funzionario"), Required(ErrorMessage="L'inserimento del nome è obbligatorio.")]
        public string NomeResponsabile {get; set;}
    }
}