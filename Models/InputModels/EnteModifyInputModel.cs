using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Toponimo")]
        public string Toponimo {get; set;}
        [Display(Name="Indirizzo")]
        public string Indirizzo {get; set;}
        [Display(Name="Civico")]
        public int Civico {get; set;}
        [Display(Name="Lettera")]
        public string Lettera {get; set;}
        [Display(Name="Località")]
        public string Localita {get; set;}
        [Display(Name="Partita IVA")]
        public string PartitaIva {get; set;}
        [Display(Name="Codice fiscale")]
        public string CodiceFiscale {get; set;}

    }
}