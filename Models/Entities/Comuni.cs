using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Comuni
    {
        public Comuni()
        {
            Regionis = new HashSet<Regioni>();
        }

        public string CodiceCatastale { get; set; }
        public string NomeComune { get; set; }
        public int CodiceRegione { get; set; }
        public int CodiceProvincia { get; set; }
        public int FlagRegione { get; set; }
        public int FlagProvincia { get; set; }
        public int Abitanti { get; set; }
        public string Prefisso { get; set; }
        public string Cap { get; set; }
        public string CodiceIstat { get; set; }

        public virtual Province CodiceProvinciaNavigation { get; set; }
        public virtual Regioni CodiceRegioneNavigation { get; set; }
        public virtual ICollection<Regioni> Regionis { get; set; }
    }
}
