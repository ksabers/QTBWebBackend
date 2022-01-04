using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface ITipiAeroportiRepository
    {
        IEnumerable<TipoAeroportoViewModel> GetTipiAeroporti();
        TipoAeroportoViewModel? GetTipiAeroporti(long idTipoAeroporto);
    }
}