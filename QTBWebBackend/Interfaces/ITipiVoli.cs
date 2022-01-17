using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface ITipiVoliRepository
    {
        IEnumerable<TipoVoloViewModel> GetTipiVoli();
        TipoVoloViewModel? GetTipiVoli(long idTipoVolo);
    }
}