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
        public string Denominazione { get; set; }
        public long TipoAeroporto { get; set; }
        public string Identificativo { get; set; }
        public string Coordinate { get; set; }
        public string Icao { get; set; }
        public string Iata { get; set; }
        public int? Qnh { get; set; }
        public string Qfu { get; set; }
        public int? Lunghezza { get; set; }
        public bool Asfalto { get; set; }
        public string Radio { get; set; }
        public string Indirizzo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Note { get; set; }

        public virtual TipiAeroporti TipoAeroportoNavigation { get; set; }
        public virtual ICollection<Persone> Persones { get; set; }
        public virtual ICollection<Voli> VoliAeroportoFineNavigations { get; set; }
        public virtual ICollection<Voli> VoliAeroportoInizioNavigations { get; set; }
    }
}
