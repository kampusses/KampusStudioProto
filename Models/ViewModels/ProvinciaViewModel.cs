using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class ProvinciaViewModel
    {
        public int CodiceProvincia {get; set;}
        public RegioneViewModel Regione {get; set;}
        public string NomeProvincia {get; set;}
        public string SiglaProvincia {get; set;}
        public static ProvinciaViewModel FromDataRow(DataRow comuneRow)
        {
            var provinciaViewModel = new ProvinciaViewModel
            {
                CodiceProvincia = Convert.ToInt32(comuneRow["codiceProvincia"]),
                Regione = null,
                NomeProvincia = Convert.ToString(comuneRow["nomeProvincia"]),
                SiglaProvincia = Convert.ToString(comuneRow["siglaProvincia"])
            };
            return provinciaViewModel;
        }
    }
}