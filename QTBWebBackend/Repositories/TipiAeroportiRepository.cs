using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class TipiAeroportiRepository: ITipiAeroportiRepository
    {
        private QTBWebDBContext _contesto;
        public TipiAeroportiRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<TipoAeroportoViewModel> GetTipiAeroporti()
        {
            return _contesto.TipiAeroportis
                .Select(tipoAeroporto => new TipoAeroportoViewModel
                {
                    Id = tipoAeroporto.Id,
                    Descrizione = tipoAeroporto.Descrizione

                }).OrderBy(tipoAeroporto => tipoAeroporto.Id);
        }

        public TipoAeroportoViewModel? GetTipoAeroporto(long idTipoAeroporto)
        {
            return _contesto.TipiAeroportis
                .Where(tipoAeroporto => tipoAeroporto.Id == idTipoAeroporto)
                .Select(tipoAeroporto => new TipoAeroportoViewModel
                {
                    Id = tipoAeroporto.Id,
                    Descrizione = tipoAeroporto.Descrizione

                }).FirstOrDefault();
        }
    }
}
