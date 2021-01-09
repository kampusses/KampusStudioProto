using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Comune
    {
        public Comune()
        {
            //Regioni = new HashSet<Regione>();
        }

        public string CodiceCatastale { get; private set; }
        public string NomeComune { get; private set; }
        public int CodiceRegione { get; private set; }
        public int CodiceProvincia { get; private set; }
        public int FlagRegione { get; private set; }
        public int FlagProvincia { get; private set; }
        public int Abitanti { get; private set; }
        public string Prefisso { get; private set; }
        public string Cap { get; private set; }
        public string CodiceIstat { get; private set; }

        public virtual Provincia Provincia { get; private set; }
        public virtual Regione Regione { get; private set; }
        //public virtual ICollection<Regione> Regioni { get; private set; }
    }
}
