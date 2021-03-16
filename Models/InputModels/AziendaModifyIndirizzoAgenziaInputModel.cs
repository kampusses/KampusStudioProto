using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyIndirizzoAgenziaInputModel
    {
        [Display(Name="Toponimo"), Required(ErrorMessage="Inserire il toponimo")]
        public string ToponimoAgenzia {get; set;}
        [Display(Name="Indirizzo"), Required(ErrorMessage="Inserire l'indirizzo")]
        public string IndirizzoAgenzia {get; set;}
        [Display(Name="Civico")]
        public int CivicoAgenzia {get; set;}
        [Display(Name="Lettera")]
        public string LetteraAgenzia {get; set;}
        [Display(Name="Località")]
        public string LocalitaAgenzia {get; set;}
        [Display(Name="Città"), Required(ErrorMessage="Inserire la città")]
        public string CittaAgenzia {get; set;}
    }
}