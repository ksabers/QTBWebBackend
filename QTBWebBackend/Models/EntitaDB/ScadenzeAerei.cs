using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class ScadenzeAerei
    {
        public long Id { get; set; }
        public long Aereo { get; set; }
        public long TipoScadenza { get; set; }
        public bool Risolta { get; set; }
        public DateTime Data { get; set; }
        public string? Note { get; set; }

        public virtual Aerei AereoNavigation { get; set; } = null!;
        public virtual TipiScadenzeAerei TipoScadenzaNavigation { get; set; } = null!;
    }
}
