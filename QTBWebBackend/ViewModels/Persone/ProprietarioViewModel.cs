using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class ProprietarioViewModel
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public int? QuotaProprieta { get; set; }
    }
}
