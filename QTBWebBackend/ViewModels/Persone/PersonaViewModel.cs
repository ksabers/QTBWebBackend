using QTBWebBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class PersonaViewModel
    {
        public long Id { get; set; }
        public bool Pilota { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Indirizzo { get; set; }
        public DateTime? DataNascita { get; set; }
        public string? LuogoNascita { get; set; }
        public string? CodiceFiscale { get; set; }
        public string? Email { get; set; }
        public string? Citta { get; set; }
        public string? Cap { get; set; }
        public string? Telefono { get; set; }
        public int NumeroVoliDaPilota { get; set; }
        public int NumeroVoliDaPasseggero { get; set; }
        public int? MinutiPregressi { get; set; }
        public int? MinutiVoloDaPilota { get; set; }
        public int? MinutiVoloDaPasseggero { get; set; }
        public long? IdAeroportoBase { get; set; }
        public string? AeroportoBase { get; set; }
        public string? Tessera { get; set; }
        public ICollection<AereoPossedutoViewModel>? AereiPosseduti { get; set; }
    }
}
