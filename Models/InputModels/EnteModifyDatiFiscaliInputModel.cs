using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyDatiFiscaliInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Partita IVA"), Required(ErrorMessage="Inserire la partita IVA")]
        public string PartitaIva {get; set;}
        [Display(Name="Codice fiscale"), Required(ErrorMessage="Inserire il codice fiscale")]
        public string CodiceFiscale {get; set;}
    }
}