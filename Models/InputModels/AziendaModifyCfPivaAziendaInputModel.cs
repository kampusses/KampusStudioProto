using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyCfPivaAziendaInputModel
    {
        [Display(Name="Partita IVA"), Required(ErrorMessage="Inserire la partita IVA")]
        public string PartitaIvaAzienda {get; set;}
        [Display(Name="Codice fiscale"), Required(ErrorMessage="Inserire il codice fiscale")]
        public string CodiceFiscaleAzienda {get; set;}
    }
}