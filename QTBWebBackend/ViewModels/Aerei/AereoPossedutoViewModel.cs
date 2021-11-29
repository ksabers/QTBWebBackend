using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class AereoPossedutoViewModel
    {
        public long Id { get; set; }
        public string? Costruttore { get; set; }
        public string? Modello { get; set; }
        public string? Marche { get; set; }
        public int? QuotaProprieta { get; set; }
    }
}
