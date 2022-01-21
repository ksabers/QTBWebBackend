using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class TipiScadenzeAereiRepository: ITipiScadenzeAereiRepository
    {
        private QTBWebDBContext _contesto;
        public TipiScadenzeAereiRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<TipoScadenzaAereoViewModel> GetTipiScadenzeAerei()
        {
            return _contesto.TipiScadenzeAereis
                .Select(tipoScadenzaAereo => new TipoScadenzaAereoViewModel
                {
                    Id = tipoScadenzaAereo.Id,
                    Descrizione = tipoScadenzaAereo.Descrizione

                }).OrderBy(tipoScadenzaAereo => tipoScadenzaAereo.Id);
        }

        public TipoScadenzaAereoViewModel? GetTipiScadenzeAerei(long idTipoScadenzaAereo)
        {
            return _contesto.TipiScadenzeAereis
                .Where(tipoScadenzaAereo => tipoScadenzaAereo.Id == idTipoScadenzaAereo)
                .Select(tipoScadenzaAereo => new TipoScadenzaAereoViewModel
                {
                    Id = tipoScadenzaAereo.Id,
                    Descrizione = tipoScadenzaAereo.Descrizione

                }).FirstOrDefault();
        }
    }
}
