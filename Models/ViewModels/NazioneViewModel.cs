using System;
using System.Collections.Generic;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class NazioneViewModel
    {
        public int CodiceContinente {get; set;}
        public string Continente {get; set;}
        public int CodiceArea {get; set;}
        public string Area {get; set;}
        public string DenominazioneIT {get; set;}
        public string DenominazioneEN {get; set;}
        public string Belfiore {get; set;}
        public string Codice2 {get; set;}
        public string Codice3 {get; set;}
        public string Codice3Padre {get; set;}
        public static NazioneViewModel FromDataRow(DataRow nazioneRow)
        {
            var nazioneViewModel = new NazioneViewModel
            {
                CodiceContinente = Convert.ToInt32(nazioneRow["codiceContinente"]),
                Continente = "",
                CodiceArea = Convert.ToInt32(nazioneRow["codiceArea"]),
                Area = "",
                DenominazioneIT = Convert.ToString(nazioneRow["denominazioneIT"]),
                DenominazioneEN = Convert.ToString(nazioneRow["denominazioneEN"]),
                Belfiore = Convert.ToString(nazioneRow["belfiore"]),
                Codice2 = Convert.ToString(nazioneRow["codice2"]),
                Codice3 = Convert.ToString(nazioneRow["codice3"]),
                Codice3Padre = Convert.ToString(nazioneRow["codice3Padre"])
            };
            switch (nazioneViewModel.CodiceContinente)
            {
                case 1:
                    nazioneViewModel.Continente = "Europa";
                    break;
                case 2:
                    nazioneViewModel.Continente = "Africa";
                    break;
                case 3:
                    nazioneViewModel.Continente = "Asia";
                    break;
                case 4:
                    nazioneViewModel.Continente = "America";
                    break;
                case 5:
                    nazioneViewModel.Continente = "Oceania";
                    break;
            };

            switch (nazioneViewModel.CodiceArea)
            {
                case 11:
                    nazioneViewModel.Area = "Unione europea";
                    break;
                case 12:
                    nazioneViewModel.Area = "Europa centro orientale";
                    break;
                case 13:
                    nazioneViewModel.Area = "Altri paesi europei";
                    break;
                case 21:
                    nazioneViewModel.Area = "Africa settentrionale";
                    break;
                case 22:
                    nazioneViewModel.Area = "Africa occidentale";
                    break;
                case 23:
                    nazioneViewModel.Area = "Africa orientale";
                    break;
                case 24:
                    nazioneViewModel.Area = "Africa centro meridionale";
                    break;
                case 31:
                    nazioneViewModel.Area = "Asia occidentale";
                    break;
                case 32:
                    nazioneViewModel.Area = "Asia centro meridionale";
                    break;
                case 33:
                    nazioneViewModel.Area = "Asia orientale";
                    break;
                case 41:
                    nazioneViewModel.Area = "America settentrionale";
                    break;
                case 42:
                    nazioneViewModel.Area = "America centro meridionale";
                    break;
                case 50:
                    nazioneViewModel.Area = "Oceania";
                    break;
            };
            return nazioneViewModel;
        }
    }
}