using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteCreateInputModel
    {
        [Required(ErrorMessage = "ATTENZIONE! Inserisci un comune valido.")]
        public string Comune {get; set;}
    }
}