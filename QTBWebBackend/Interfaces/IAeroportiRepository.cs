using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface IAeroportiRepository
    {
        IEnumerable<AeroportoViewModel> GetAeroporti();
        AeroportoViewModel? GetAeroporto(long idAeroporto);
    }
}