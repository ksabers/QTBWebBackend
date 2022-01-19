using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class TipiManutenzioni
    {
        public TipiManutenzioni()
        {
            Manutenzionis = new HashSet<Manutenzioni>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; } = null!;

        public virtual ICollection<Manutenzioni> Manutenzionis { get; set; }
    }
}
