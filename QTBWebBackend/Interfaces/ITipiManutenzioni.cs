using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface ITipiManutenzioniRepository
    {
        IEnumerable<TipoManutenzioneViewModel> GetTipiManutenzioni();
        TipoManutenzioneViewModel? GetTipiManutenzioni(long idTipoManutenzione);
    }
}