using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyIndirizzoAziendaInputModel
    {
        [Display(Name="Toponimo"), Required(ErrorMessage="Inserire il toponimo")]
        public string ToponimoAzienda {get; set;}
        [Display(Name="Indirizzo"), Required(ErrorMessage="Inserire l'indirizzo")]
        public string IndirizzoAzienda {get; set;}
        [Display(Name="Civico")]
        public int CivicoAzienda {get; set;}
        [Display(Name="Lettera")]
        public string LetteraAzienda {get; set;}
        [Display(Name="Località")]
        public string LocalitaAzienda {get; set;}
    }
}