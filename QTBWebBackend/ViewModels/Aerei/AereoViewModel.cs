using QTBWebBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class AereoViewModel
    {
        public long Id { get; set; }
        public string? Costruttore { get; set; }
        public string? Modello { get; set; }
        public string? Marche { get; set; }
        public long MinutiPregressi { get; set; }
        public int? MinutiVolo { get; set; }
        public Voli? VoloPiuRecente { get; set; }
        public ICollection<ProprietarioViewModel>? Proprietari { get; set; }
    }
}
