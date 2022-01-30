using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QTBWebBackend.Interfaces
{
    public interface IScadenzeRepository
    {
        IEnumerable<ScadenzeViewModel> GetScadenze();
        ScadenzeViewModel? GetScadenze(long idPersona);
        Task<ScadenzeAerei?> PostScadenzaAereo(ScadenzaAereoViewModel scadenzaAereo);
        //ScadenzeViewModel? GetScadenzeInScadenzaSingolaPersona(long idPersona, int giorni);
        //IEnumerable<ScadenzaAereoViewModel> GetScadenzeAerei();
        //ScadenzaAereoViewModel? GetScadenzaAereo(long idScadenza);
        //IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersone();
        //ScadenzaPersonaViewModel? GetScadenzaPersona(long idScadenza);
    }
}