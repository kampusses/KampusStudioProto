namespace KampusStudioProto.Models.ViewModels
{
    public class ComuneViewModel
    {
        public string CodiceCatastale {get; set;}
        public string NomeComune {get; set;}
        public int Abitanti {get; set;}
        public bool FlagRagione {get; set;}
        public bool FlagProvincia {get; set;}
        public RegioneViewModel Regione {get; set;}
        public ProvinciaViewModel Provincia {get; set;}
        public string Cap {get; set;}
        public string Prefisso {get; set;}
        public string CodiceIstat {get; set;}
    }
}