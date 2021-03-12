using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class AziendaModifyNomeAziendaInputModel
    {
        [Required(ErrorMessage = "ATTENZIONE! E' richiesto l'inserimento del nome azienda."), Display(Name="Nome Azienda")]
        public string NomeAzienda {get; set;}
    }
}