using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class ScadenzePersone
    {
        public long Id { get; set; }
        public long Persona { get; set; }
        public long TipoScadenza { get; set; }
        public bool Risolta { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }

        public virtual Persone PersonaNavigation { get; set; }
        public virtual TipiScadenzePersone TipoScadenzaNavigation { get; set; }
    }
}
