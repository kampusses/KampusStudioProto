using System.ComponentModel.DataAnnotations;

namespace KampusStudioProto.Models.InputModels
{
    public class EnteModifyContattiInputModel
    {
        public string CodiceCatastale {get; set;}
        [Display(Name="Telefono")]
        public string Telefono {get; set;}
        [Display(Name="Fax")]
        public string Fax {get; set;}
        [Display(Name="Email")]
        public string Email {get; set;}
        [Display(Name="Pec")]
        public string Pec {get; set;}
    }
}