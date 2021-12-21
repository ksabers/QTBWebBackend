using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class Ruoli
    {
        public Ruoli()
        {
            Logins = new HashSet<Login>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
    }
}
