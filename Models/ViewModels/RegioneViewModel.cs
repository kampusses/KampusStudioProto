using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class RegioneViewModel
    {
        public int CodiceRegione {get; set;}
        public string NomeRegione {get; set;}
        public RipartizioneGeografica RipartizioneGeografica {get; set;}
        public string CodiceCapoluogo {get; set;}
        public static RegioneViewModel FromDataRow(DataRow comuneRow)
        {
            var regioneViewModel = new RegioneViewModel
            {
                CodiceRegione = Convert.ToInt32(comuneRow["codiceRegione"]),
                NomeRegione = Convert.ToString(comuneRow["nomeRegione"]),
                RipartizioneGeografica = (RipartizioneGeografica) comuneRow["ripartizioneGeografica"] - 1,
                CodiceCapoluogo = Convert.ToString(comuneRow["codiceCapoluogo"])
            };
            return regioneViewModel;
        }
    }
}