using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Province
    {
        public Province()
        {
            Comunis = new HashSet<Comuni>();
        }

        public int CodiceProvincia { get; set; }
        public int CodiceRegione { get; set; }
        public string NomeProvincia { get; set; }
        public string SiglaProvincia { get; set; }

        public virtual Regioni CodiceRegioneNavigation { get; set; }
        public virtual ICollection<Comuni> Comunis { get; set; }
    }
}
