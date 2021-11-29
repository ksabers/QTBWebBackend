using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface IAereiRepository
    {
        IEnumerable<AereoViewModel> GetAerei();
        AereoViewModel? GetAereo(long idAereo);
    }
}