using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyEmailPecAgenziaInputModel
    {
        [Display(Name="Email"), EmailAddress(ErrorMessage="Inserire un indirizzo email corretto")]
        public string EmailAgenzia {get; set;}
        [Display(Name="Pec"), EmailAddress(ErrorMessage="Inserire un indirizzo Pec corretto")]
        public string PecAgenzia {get; set;}
    }
}