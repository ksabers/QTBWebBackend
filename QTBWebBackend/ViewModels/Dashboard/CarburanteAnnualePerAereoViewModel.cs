using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels

{

    public class ConsumoVoli
    {
        public DateTime? Data { get; set; }
        public int? Consumo { get; set; }

    }
    public class ConsumoAerei
    {
        public string? Marche { get; set; }
        public ConsumoVoli[]? Voli { get; set; }
    }

}
