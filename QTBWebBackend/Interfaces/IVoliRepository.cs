using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QTBWebBackend.Interfaces
{
    public interface IVoliRepository
    {
        IEnumerable<VoloViewModel> GetVoli();
        VoloViewModel? GetVolo(long idVolo);
        Task<bool> PostVolo(VoloViewModel volo);
    }
}