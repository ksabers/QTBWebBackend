using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class TipiScadenzeAerei
    {
        public TipiScadenzeAerei()
        {
            ScadenzeAereis = new HashSet<ScadenzeAerei>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; } = null!;

        public virtual ICollection<ScadenzeAerei> ScadenzeAereis { get; set; }
    }
}
