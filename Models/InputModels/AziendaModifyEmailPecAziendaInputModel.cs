using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyEmailPecAziendaInputModel
    {
        [Display(Name="Email"), EmailAddress(ErrorMessage="Inserire un indirizzo email corretto")]
        public string EmailAzienda {get; set;}
        [Display(Name="Pec"), EmailAddress(ErrorMessage="Inserire un indirizzo Pec corretto")]
        public string PecAzienda {get; set;}
    }
}