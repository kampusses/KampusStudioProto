using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Comuni = new HashSet<Comune>();
        }

        public int CodiceProvincia { get; private set; }
        public int CodiceRegione { get; private set; }
        public string NomeProvincia { get; private set; }
        public string SiglaProvincia { get; private set; }

        public virtual Regione Regione { get; private set; }
        public virtual ICollection<Comune> Comuni { get; private set; }
    }
}
