using System;

namespace QTBWebBackend.ViewModels
{
    public class SingolaScadenzaGenericaViewModel
    {
        public long Id { get; set; }
        public string? Tipo { get; set; }
        public DateTime? Data { get; set; }
        public int? Minuti { get; set; }
        public string? Note { get; set; }
    }
}
