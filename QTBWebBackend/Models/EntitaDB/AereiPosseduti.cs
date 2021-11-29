using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class AereiPosseduti
    {
        public long Id { get; set; }
        public long Persona { get; set; }
        public long Aereo { get; set; }
        public int? Quota { get; set; }

        public virtual Aerei AereoNavigation { get; set; }
        public virtual Persone PersonaNavigation { get; set; }
    }
}
