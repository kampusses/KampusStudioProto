using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class ComuneViewModel
    {
        public string CodiceCatastale {get; set;}
        public string NomeComune {get; set;}
        public int Abitanti {get; set;}
        public bool FlagRegione {get; set;}
        public bool FlagProvincia {get; set;}
        public RegioneViewModel Regione {get; set;}
        public ProvinciaViewModel Provincia {get; set;}
        public string Cap {get; set;}
        public string Prefisso {get; set;}
        public string CodiceIstat {get; set;}

        public static ComuneViewModel FromDataRow(DataRow comuneRow)
        {
            var comuneViewModel = new ComuneViewModel
            {
                CodiceCatastale = Convert.ToString(comuneRow["codiceCatastale"]),
                NomeComune = Convert.ToString(comuneRow["nomeComune"]),
                Abitanti = Convert.ToInt32(comuneRow["abitanti"]),
                FlagRegione = Convert.ToBoolean(comuneRow["flagRegione"]),
                FlagProvincia = Convert.ToBoolean(comuneRow["flagProvincia"]),
                Regione = null,
                Provincia = null,
                Cap = Convert.ToString(comuneRow["cap"]),
                Prefisso = Convert.ToString(comuneRow["prefisso"]),
                CodiceIstat = Convert.ToString(comuneRow["codiceIstat"])
            };
            return comuneViewModel;
        }
    }
}