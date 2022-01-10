﻿namespace QTBWebBackend.ViewModels
{
    public class ScadenzeViewModel
    {
        public long Persona { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public int? MinutiPregressi { get; set; }
        public int? MinutiVoloDaPilota { get; set; }
        public SingolaScadenzaGenericaViewModel[]? ScadenzePersona { get; set; }
        public ScadenzeDiUnAereoViewModel[]? ScadenzeAerei { get; set; }
    }
}
