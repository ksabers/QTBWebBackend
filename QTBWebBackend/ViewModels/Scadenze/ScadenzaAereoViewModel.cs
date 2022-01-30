using System;

namespace QTBWebBackend.ViewModels
{
    public class ScadenzaAereoViewModel
    {
        public long Id { get; set; }
        public long Aereo { get; set; }
        public string? Modello { get; set; }
        public string? Marche { get; set; }
        public int MinutiPregressi { get; set; }
        public int? MinutiVolo { get; set; }
        public long IdTipoScadenza { get; set; }
        public string? TipoScadenza { get; set; }
        public bool Risolta { get; set; }
        public DateTime Data { get; set; }
        public int? Minuti { get; set; }
        public string? Note { get; set; }
    }
}
