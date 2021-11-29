using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface IDashboardRepository
    {
        IEnumerable<OreDiVoloPerPilotaViewModel> GetOreDiVoloPerPilota();
        IEnumerable<OreDiVoloPerAereoViewModel> GetOreDiVoloPerAereo();
    }
}