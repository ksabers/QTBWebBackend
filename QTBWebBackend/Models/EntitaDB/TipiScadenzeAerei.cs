using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class TipiScadenzeAerei
    {
        public TipiScadenzeAerei()
        {
            ScadenzeAereis = new HashSet<ScadenzeAerei>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<ScadenzeAerei> ScadenzeAereis { get; set; }
    }
}
