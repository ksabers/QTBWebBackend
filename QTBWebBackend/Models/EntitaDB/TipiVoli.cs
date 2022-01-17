using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class TipiVoli
    {
        public TipiVoli()
        {
            Volis = new HashSet<Voli>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; } = null!;

        public virtual ICollection<Voli> Volis { get; set; }
    }
}
