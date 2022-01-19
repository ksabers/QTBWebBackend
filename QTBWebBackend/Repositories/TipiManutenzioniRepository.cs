using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class TipiManutenzioniRepository: ITipiManutenzioniRepository
    {
        private QTBWebDBContext _contesto;
        public TipiManutenzioniRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<TipoManutenzioneViewModel> GetTipiManutenzioni()
        {
            return _contesto.TipiManutenzionis
                .Select(tipoManutenzione => new TipoManutenzioneViewModel
                {
                    Id = tipoManutenzione.Id,
                    Descrizione = tipoManutenzione.Descrizione

                }).OrderBy(tipoManutenzione => tipoManutenzione.Id);
        }

        public TipoManutenzioneViewModel? GetTipiManutenzioni(long idTipoManutenzione)
        {
            return _contesto.TipiManutenzionis
                .Where(tipoManutenzione => tipoManutenzione.Id == idTipoManutenzione)
                .Select(tipoManutenzione => new TipoManutenzioneViewModel
                {
                    Id = tipoManutenzione.Id,
                    Descrizione = tipoManutenzione.Descrizione

                }).FirstOrDefault();
        }
    }
}
