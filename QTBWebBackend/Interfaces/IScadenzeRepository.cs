using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QTBWebBackend.Interfaces
{
    public interface IScadenzeRepository
    {
        // tutte senza filtri (GET tutte)
        IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersone();  // GET scadenzepersone
        IEnumerable<ScadenzaAereoViewModel> GetScadenzeAerei();  // GET scadenzeaerei

        // singola scadenza (GET/id)
        ScadenzaPersonaViewModel? GetScadenzePersone(long idScadenza);  // GET scadenzepersone/id
        ScadenzaAereoViewModel? GetScadenzeAerei(long idScadenza);  // GET scadenzeaerei/id

        // tutte di una persona
        IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersoneDiUnaPersona(long idPersona); // GET scadenzepersone/persona/id
        IEnumerable<ScadenzaAereoViewModel> GetScadenzeAereiDiUnaPersona(long idPersona);  // GET scadenzeaerei/persona/id

        // tutte di un aereo
        IEnumerable<ScadenzaAereoViewModel> GetScadenzeAereiDiUnAereo(long idAereo);  // GET scadenzeaerei/aereo/id

        // tutti i tipi
        IEnumerable<TipoScadenzaPersonaViewModel> GetTipiScadenzePersone();  // GET scadenzepersone/tipi
        IEnumerable<TipoScadenzaAereoViewModel> GetTipiScadenzeAerei();  // GET scadenzeaerei/tipi

        // singolo tipo
        TipoScadenzaPersonaViewModel? GetTipiScadenzePersone(long idTipoScadenzaPersona);  // GET scadenzepersone/tipi/id
        TipoScadenzaAereoViewModel? GetTipiScadenzeAerei(long idTipoScadenzaAereo);  // GET scadenzeaerei/tipi/id

        // post
        Task<ScadenzeAerei?> PostScadenzaAereo(ScadenzaAereoViewModel scadenzaAereo);  // POST scadenzeaerei
    }
}