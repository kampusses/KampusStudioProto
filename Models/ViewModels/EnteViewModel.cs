using System;
using System.Data;

namespace KampusStudioProto.Models.ViewModels
{
    public class EnteViewModel
    {
        public string CodiceCatastale {get; set;}
        public ComuneViewModel Comune {get; set;}
        public string PartitaIva {get; set;}
        public string CodiceFiscale {get; set;}
        public string Toponimo {get; set;}
        public string Indirizzo {get; set;}
        public int Civico {get; set;}
        public string Lettera {get; set;}
        public string Localita {get; set;}
        public string Telefono {get; set;}
        public string Fax {get; set;}
        public string Email {get; set;}
        public string Pec {get; set;}
        public string TitoloResponsabile {get; set;}
        public string CognomeResponsabile {get; set;}
        public string NomeResponsabile {get; set;}
        public string Card {get; set;}
        public static EnteViewModel FromDataRow(DataRow enteRow)
        {
            var enteViewModel = new EnteViewModel
            {
                CodiceCatastale = Convert.ToString(enteRow["codiceCatastale"]),
                Comune = null,
                PartitaIva = Convert.ToString(enteRow["partitaIva"]),
                CodiceFiscale = Convert.ToString(enteRow["codiceFiscale"]),
                Toponimo = Convert.ToString(enteRow["toponimo"]),
                Indirizzo = Convert.ToString(enteRow["indirizzo"]),
                Civico = Convert.ToInt32(enteRow["civico"]),
                Lettera = Convert.ToString(enteRow["lettera"]),
                Localita = Convert.ToString(enteRow["localita"]),
                Telefono = Convert.ToString(enteRow["telefono"]),
                Fax = Convert.ToString(enteRow["fax"]),
                Email = Convert.ToString(enteRow["email"]),
                Pec = Convert.ToString(enteRow["pec"]),
                TitoloResponsabile = Convert.ToString(enteRow["titoloResponsabile"]),
                CognomeResponsabile = Convert.ToString(enteRow["cognomeResponsabile"]),
                NomeResponsabile = Convert.ToString(enteRow["nomeResponsabile"]),
                Card = ""
            };
            return enteViewModel;
        }
    }
}