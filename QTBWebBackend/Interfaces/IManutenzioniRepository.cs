using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface IManutenzioniRepository
    {
        IEnumerable<ManutenzioneViewModel> GetManutenzioni();
        ManutenzioneViewModel? GetManutenzioni(long idManutenzione);
    }
}