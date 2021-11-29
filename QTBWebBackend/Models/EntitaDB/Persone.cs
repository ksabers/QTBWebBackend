using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class Persone
    {
        public Persone()
        {
            AereiPossedutis = new HashSet<AereiPosseduti>();
            Logins = new HashSet<Login>();
            Manutenzionis = new HashSet<Manutenzioni>();
            ScadenzePersones = new HashSet<ScadenzePersone>();
            VoliPasseggeroNavigations = new HashSet<Voli>();
            VoliPilotaNavigations = new HashSet<Voli>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string Telefono { get; set; }
        public bool Pilota { get; set; }
        public int? MinutiPregressi { get; set; }
        public long? AeroportoBase { get; set; }
        public string Tessera { get; set; }

        public virtual Aeroporti AeroportoBaseNavigation { get; set; }
        public virtual ICollection<AereiPosseduti> AereiPossedutis { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Manutenzioni> Manutenzionis { get; set; }
        public virtual ICollection<ScadenzePersone> ScadenzePersones { get; set; }
        public virtual ICollection<Voli> VoliPasseggeroNavigations { get; set; }
        public virtual ICollection<Voli> VoliPilotaNavigations { get; set; }
    }
}
