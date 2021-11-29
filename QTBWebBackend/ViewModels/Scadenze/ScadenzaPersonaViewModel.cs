using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class ScadenzaPersonaViewModel
    {
        public long Id { get; set; }
        public long Persona { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public long IdTipoScadenza { get; set; }
        public string? TipoScadenza { get; set; }
        public bool Risolta { get; set; }
        public DateTime Data { get; set; }
        public string? Note { get; set; }
    }
}
