using System;
using System.Collections.Generic;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class ProvinciaViewModel
    {
        public int CodiceProvincia {get; set;}
        public RegioneViewModel Regione {get; set;}
        public ComuneViewModel Capoluogo {get; set;}
        public string NomeProvincia {get; set;}
        public string SiglaProvincia {get; set;}
        public int NComuni {get; set;}
        public int Abitanti {get; set;}
        public static ProvinciaViewModel FromDataRow(DataRow comuneRow)
        {
            var provinciaViewModel = new ProvinciaViewModel
            {
                CodiceProvincia = Convert.ToInt32(comuneRow["codiceProvincia"]),
                Regione = null,
                Capoluogo = null,
                NomeProvincia = Convert.ToString(comuneRow["nomeProvincia"]),
                SiglaProvincia = Convert.ToString(comuneRow["siglaProvincia"]),
                NComuni = 0,
                Abitanti = 0
            };
            return provinciaViewModel;
        }
    }
}