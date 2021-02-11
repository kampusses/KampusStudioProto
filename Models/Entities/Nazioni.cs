using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Nazione
    {
        public int CodiceContinente { get; private set; }
        public int CodiceArea { get; private set; }
        public string DenominazioneIt { get; private set; }
        public string DenominazioneEn { get; private set; }
        public string Belfiore { get; private set; }
        public string Codice2 { get; private set; }
        public string Codice3 { get; private set; }
        public string Codice3Padre { get; private set; }
    }
}
