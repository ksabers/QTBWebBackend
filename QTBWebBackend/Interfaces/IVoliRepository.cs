using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QTBWebBackend.Interfaces
{
    public interface IVoliRepository
    {
        IEnumerable<VoloViewModel> GetVoli();
        IEnumerable<VoloViewModel> GetVoliDiUnAereo(long idAereo);
        VoloViewModel? GetVoli(long idVolo);
        Task<Voli?> PostVolo(VoloViewModel volo);
    }
}