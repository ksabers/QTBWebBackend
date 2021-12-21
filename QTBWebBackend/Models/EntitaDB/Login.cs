using System;
using System.Collections.Generic;

namespace QTBWebBackend.Models
{
    public partial class Login
    {
        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long Persona { get; set; }
        public long Ruolo { get; set; }

        public virtual Persone PersonaNavigation { get; set; } = null!;
        public virtual Ruoli RuoloNavigation { get; set; } = null!;
    }
}
