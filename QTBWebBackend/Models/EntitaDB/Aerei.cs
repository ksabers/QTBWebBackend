using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class Aerei
    {
        public Aerei()
        {
            AereiPossedutis = new HashSet<AereiPosseduti>();
            Manutenzionis = new HashSet<Manutenzioni>();
            ScadenzeAereis = new HashSet<ScadenzeAerei>();
            Volis = new HashSet<Voli>();
        }

        public long Id { get; set; }
        public string Costruttore { get; set; }
        public string Modello { get; set; }
        public string Marche { get; set; }
        public int MinutiPregressi { get; set; }

        public virtual ICollection<AereiPosseduti> AereiPossedutis { get; set; }
        public virtual ICollection<Manutenzioni> Manutenzionis { get; set; }
        public virtual ICollection<ScadenzeAerei> ScadenzeAereis { get; set; }
        public virtual ICollection<Voli> Volis { get; set; }
    }
}
