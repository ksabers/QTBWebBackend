using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWeb.Models
{
    public class AeroportiRepository : IAeroportiRepository
    {
        private QTBWebContext _contesto;
        public AeroportiRepository(QTBWebContext contesto)
        {
            _contesto = contesto;
        }
        public IEnumerable<Aeroporti> LeggiAeroporti()
        {
            return _contesto.Aeroportis.ToList();
        }
    }
}
