using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class TipiVoliRepository: ITipiVoliRepository
    {
        private QTBWebDBContext _contesto;
        public TipiVoliRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<TipoVoloViewModel> GetTipiVoli()
        {
            return _contesto.TipiVolis
                .Select(tipoVolo => new TipoVoloViewModel
                {
                    Id = tipoVolo.Id,
                    Descrizione = tipoVolo.Descrizione

                }).OrderBy(tipoVolo => tipoVolo.Id);
        }

        public TipoVoloViewModel? GetTipiVoli(long idTipoVolo)
        {
            return _contesto.TipiVolis
                .Where(tipoVolo => tipoVolo.Id == idTipoVolo)
                .Select(tipoVolo => new TipoVoloViewModel
                {
                    Id = tipoVolo.Id,
                    Descrizione = tipoVolo.Descrizione

                }).FirstOrDefault();
        }
    }
}
