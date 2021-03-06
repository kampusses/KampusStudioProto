using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class AziendaViewModel
    {
        public string NomeAzienda {get; set;}
        
        public static AziendaViewModel FromDataRow(DataRow aziendaRow)
        {
            var aziendaViewModel = new AziendaViewModel
            {
                NomeAzienda = Convert.ToString(aziendaRow["nomeAzienda"])
            };
            return aziendaViewModel;
        }
    }
}