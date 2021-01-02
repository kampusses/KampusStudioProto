using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class RegioneViewModel
    {
        public int CodiceRegione {get; set;}
        public string NomeRegione {get; set;}
        public int RipartizioneGeografica {get; set;}
        public string CodiceCapoluogo {get; set;}
        public static RegioneViewModel FromDataRow(DataRow comuneRow)
        {
            var regioneViewModel = new RegioneViewModel
            {
                CodiceRegione = Convert.ToInt32(comuneRow["codiceRegione"]),
                NomeRegione = Convert.ToString(comuneRow["nomeRegione"]),
                RipartizioneGeografica = Convert.ToInt32(comuneRow["ripartizioneGeografica"]),
                CodiceCapoluogo = Convert.ToString(comuneRow["codiceCapoluogo"])
            };
            return regioneViewModel;
        }
    }
}