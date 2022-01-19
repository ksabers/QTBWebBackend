using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class Manutenzioni
    {
        public long Id { get; set; }
        public bool? Ordinaria { get; set; }
        public long Tipo { get; set; }
        public string Descrizione { get; set; } = null!;
        public DateTime Data { get; set; }
        public long Aereo { get; set; }
        public long? Persona { get; set; }
        public long? Volo { get; set; }

        public virtual Aerei AereoNavigation { get; set; } = null!;
        public virtual Persone? PersonaNavigation { get; set; }
        public virtual TipiManutenzioni TipoNavigation { get; set; } = null!;
        public virtual Voli? VoloNavigation { get; set; }
    }
}
