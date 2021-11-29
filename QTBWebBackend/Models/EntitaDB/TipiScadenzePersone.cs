using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class TipiScadenzePersone
    {
        public TipiScadenzePersone()
        {
            ScadenzePersones = new HashSet<ScadenzePersone>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<ScadenzePersone> ScadenzePersones { get; set; }
    }
}
