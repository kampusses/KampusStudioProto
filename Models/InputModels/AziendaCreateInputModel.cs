using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaCreateInputModel
    {
        [Required(ErrorMessage = "ATTENZIONE! E' richiesto l'inserimento del nome azienda.")]
        public string Azienda {get; set;}
    }
}