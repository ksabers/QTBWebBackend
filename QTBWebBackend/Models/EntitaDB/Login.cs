using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class Login
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Persona { get; set; }
        public long Ruolo { get; set; }

        public virtual Persone PersonaNavigation { get; set; }
        public virtual Ruoli RuoloNavigation { get; set; }
    }
}
