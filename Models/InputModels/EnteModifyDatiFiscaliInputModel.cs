using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyDatiFiscaliInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Partita IVA")]
        public string PartitaIva {get; set;}
        [Display(Name="Codice fiscale")]
        public string CodiceFiscale {get; set;}
    }
}