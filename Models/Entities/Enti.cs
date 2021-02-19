using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Ente
    {
        public string CodiceCatastale { get; private set; }
        public virtual Comune Comune { get; private set; }
        public string PartitaIva { get; private set; }
        public string CodiceFiscale { get; private set; }
        public string Toponimo { get; private set; }
        public string Indirizzo { get; private set; }
        public int Civico { get; private set; }
        public string Lettera { get; private set; }
        public string Localita { get; private set; }
        public string Telefono { get; private set; }
        public string Fax { get; private set; }
        public string Email { get; private set; }
        public string Pec { get; private set; }
        public string TitoloResponsabile { get; private set; }
        public string CognomeResponsabile { get; private set; }
        public string NomeResponsabile { get; private set; }
    }
}
