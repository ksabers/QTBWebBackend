using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class TipiAeroporti
    {
        public TipiAeroporti()
        {
            Aeroportis = new HashSet<Aeroporti>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; } = null!;

        public virtual ICollection<Aeroporti> Aeroportis { get; set; }
    }
}
