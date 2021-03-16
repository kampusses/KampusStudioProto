using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyTelefonoFaxAgenziaInputModel
    {
        [Display(Name="Telefono"), Phone(ErrorMessage="Inserire il numero di telefono nel seguente formato: +39 0883 656565. Il prefisso internazionale è opzionale")]
        public string TelefonoAgenzia {get; set;}
        [Display(Name="Fax"), Phone(ErrorMessage="Inserire il numero di fax nel seguente formato: +39 0883 656565. Il prefisso internazionale è opzionale")]
        public string FaxAgenzia {get; set;}
    }
}