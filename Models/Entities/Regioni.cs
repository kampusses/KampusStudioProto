using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Regioni
    {
        public Regioni()
        {
            Comunis = new HashSet<Comuni>();
            Provinces = new HashSet<Province>();
        }

        public int CodiceRegione { get; set; }
        public string NomeRegione { get; set; }
        public int RipartizioneGeografica { get; set; }
        public string CodiceCapoluogo { get; set; }

        public virtual Comuni CodiceCapoluogoNavigation { get; set; }
        public virtual ICollection<Comuni> Comunis { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
