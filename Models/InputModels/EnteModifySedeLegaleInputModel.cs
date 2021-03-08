using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifySedeLegaleInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Toponimo"), Required(ErrorMessage="Inserire il toponimo")]
        public string Toponimo {get; set;}
        [Display(Name="Indirizzo"), Required(ErrorMessage="Inserire l'indirizzo")]
        public string Indirizzo {get; set;}
        [Display(Name="Civico")]
        public int Civico {get; set;}
        [Display(Name="Lettera")]
        public string Lettera {get; set;}
        [Display(Name="Località")]
        public string Localita {get; set;}
    }
}