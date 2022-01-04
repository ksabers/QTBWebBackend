using QTBWebBackend.ViewModels;
using System.Collections.Generic;

namespace QTBWebBackend.Interfaces
{
    public interface IScadenzeRepository
    {
        IEnumerable<ScadenzeViewModel> GetScadenze();
        ScadenzeViewModel? GetScadenze(long idPersona);
        //ScadenzeViewModel? GetScadenzeInScadenzaSingolaPersona(long idPersona, int giorni);
        //IEnumerable<ScadenzaAereoViewModel> GetScadenzeAerei();
        //ScadenzaAereoViewModel? GetScadenzaAereo(long idScadenza);
        //IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersone();
        //ScadenzaPersonaViewModel? GetScadenzaPersona(long idScadenza);
    }
}