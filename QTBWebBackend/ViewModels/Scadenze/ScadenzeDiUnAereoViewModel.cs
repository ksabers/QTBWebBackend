namespace QTBWebBackend.ViewModels
{
    public class ScadenzeDiUnAereoViewModel
    {
        public long Aereo { get; set; }
        public string? Modello { get; set; }
        public string? Marche { get; set; }
        public int MinutiPregressi { get; set; }
        public int? MinutiVolo { get; set; }
        public SingolaScadenzaGenericaViewModel[]? ScadenzeAereo { get; set; }
    }
}
