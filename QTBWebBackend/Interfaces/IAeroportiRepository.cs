using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QTBWebBackend.Interfaces
{
    public interface IAeroportiRepository
    {
        IEnumerable<AeroportoViewModel> GetAeroporti();
        AeroportoViewModel? GetAeroporti(long idAeroporto);
        IEnumerable<TipoAeroportoViewModel> GetTipiAeroporti();
        TipoAeroportoViewModel? GetTipiAeroporti(long idTipoAeroporto);

        Task<Aeroporti?> PostAeroporto(AeroportoViewModel aeroporto);
    }
}