using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface ITipiScadenzeAereiRepository
    {
        IEnumerable<TipoScadenzaAereoViewModel> GetTipiScadenzeAerei();
        TipoScadenzaAereoViewModel? GetTipiScadenzeAerei(long idTipoScadenzaAereo);
    }
}