using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyTelefonoFaxAziendaInputModel
    {
        [Display(Name="Telefono")]
        public string TelefonoAzienda {get; set;}
        [Display(Name="Fax")]
        public string FaxAzienda {get; set;}
    }
}