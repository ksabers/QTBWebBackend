using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class Aeroporti
    {
        public Aeroporti()
        {
            Persones = new HashSet<Persone>();
            VoliAeroportoFineNavigations = new HashSet<Voli>();
            VoliAeroportoInizioNavigations = new HashSet<Voli>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Identificativo { get; set; }
        public string Coordinate { get; set; }

        public virtual ICollection<Persone> Persones { get; set; }
        public virtual ICollection<Voli> VoliAeroportoFineNavigations { get; set; }
        public virtual ICollection<Voli> VoliAeroportoInizioNavigations { get; set; }
    }
}
