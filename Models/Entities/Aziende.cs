using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Azienda
    {
        public Azienda(string nomeAzienda)
        {
            NomeAzienda = nomeAzienda;
        }
        public string NomeAzienda { get; private set; }
    }
}
