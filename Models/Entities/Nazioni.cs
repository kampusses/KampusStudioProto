using System;
using System.Collections.Generic;

#nullable disable

namespace KampusStudioProto.Models.Entities
{
    public partial class Nazioni
    {
        public int? CodiceContinente { get; set; }
        public int? CodiceArea { get; set; }
        public string DenominazioneIt { get; set; }
        public string DenominazioneEn { get; set; }
        public string Belfiore { get; set; }
        public string Codice2 { get; set; }
        public string Codice3 { get; set; }
        public string Codice3Padre { get; set; }
    }
}
