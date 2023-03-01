using Microsoft.EntityFrameworkCore;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.Repositories
{
    public class ScadenzeRepository : IScadenzeRepository
    {
        private QTBWebDBContext _contesto;

        public ScadenzeRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        // GET scadenzepersone
        public IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersone()
        {
            return _contesto.ScadenzePersone
                .Where(scadenza => scadenza.Risolta == false)
                .Select(scadenza => new ScadenzaPersonaViewModel
                {
                    Id = scadenza.Id,
                    Persona = scadenza.PersonaNavigation.Id,
                    Nome = scadenza.PersonaNavigation.Nome,
                    Cognome = scadenza.PersonaNavigation.Cognome,
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                });
        }

        // GET scadenzeaerei
        public IEnumerable<ScadenzaAereoViewModel> GetScadenzeAerei()
        {
            return _contesto.ScadenzeAerei
                .Where(scadenza => scadenza.Risolta == false)
                .Select(scadenza => new ScadenzaAereoViewModel
                {
                    Id = scadenza.Id,
                    Aereo = scadenza.Aereo,
                    Modello = scadenza.AereoNavigation.Modello,
                    Marche = scadenza.AereoNavigation.Marche,
                    MinutiPregressi = scadenza.AereoNavigation.MinutiPregressi,
                    MinutiVolo = scadenza.AereoNavigation.Voli.Sum(volo => volo.Durata),
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                });
        }

        // GET scadenzepersone/id
        public ScadenzaPersonaViewModel? GetScadenzePersone(long idScadenza)
        {
            return _contesto.ScadenzePersone
                .Where(scadenza => scadenza.Id == idScadenza)
                .Select(scadenza => new ScadenzaPersonaViewModel
                {
                    Id = scadenza.Id,
                    Persona = scadenza.PersonaNavigation.Id,
                    Nome = scadenza.PersonaNavigation.Nome,
                    Cognome = scadenza.PersonaNavigation.Cognome,
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                }).FirstOrDefault();
        }

        // GET scadenzeaerei/id
        public ScadenzaAereoViewModel? GetScadenzeAerei(long idScadenza)
        {
            return _contesto.ScadenzeAerei
                .Where(scadenza => scadenza.Id == idScadenza)
                .Select(scadenza => new ScadenzaAereoViewModel
                {
                    Id = scadenza.Id,
                    Aereo = scadenza.Aereo,
                    Modello = scadenza.AereoNavigation.Modello,
                    Marche = scadenza.AereoNavigation.Marche,
                    MinutiPregressi = scadenza.AereoNavigation.MinutiPregressi,
                    MinutiVolo = scadenza.AereoNavigation.Voli.Sum(volo => volo.Durata),
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                }).FirstOrDefault();
        }
        
        // GET scadenzepersone/persona/id
        public IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersoneDiUnaPersona(long idPersona)
        {
            return _contesto.ScadenzePersone
                .Where(scadenza => scadenza.Persona == idPersona)
                .Where(scadenza => scadenza.Risolta == false)
                .Select(scadenza => new ScadenzaPersonaViewModel
                {
                    Id = scadenza.Id,
                    Persona = scadenza.PersonaNavigation.Id,
                    Nome = scadenza.PersonaNavigation.Nome,
                    Cognome = scadenza.PersonaNavigation.Cognome,
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                });
        }

        // GET scadenzeaerei/persona/id
        public IEnumerable<ScadenzaAereoViewModel> GetScadenzeAereiDiUnaPersona(long idPersona)
        {
            return _contesto.ScadenzeAerei
                .Where(scadenza => scadenza.AereoNavigation.AereiPosseduti.Any(aereo => aereo.Persona == idPersona))
                .Where(scadenza => scadenza.Risolta == false)
                .Select(scadenza => new ScadenzaAereoViewModel
                {
                    Id = scadenza.Id,
                    Modello = scadenza.AereoNavigation.Modello,
                    Marche = scadenza.AereoNavigation.Marche,
                    MinutiPregressi = scadenza.AereoNavigation.MinutiPregressi,
                    MinutiVolo = scadenza.AereoNavigation.Voli.Sum(volo => volo.Durata),
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                });
        }

        // GET scadenzeaerei/aereo/id
        public IEnumerable<ScadenzaAereoViewModel> GetScadenzeAereiDiUnAereo(long idAereo)
        {
            return _contesto.ScadenzeAerei
                .Where(scadenza => scadenza.Aereo == idAereo)
                .Where(scadenza => scadenza.Risolta == false)
                .Select(scadenza => new ScadenzaAereoViewModel
                {
                    Id = scadenza.Id,
                    Modello = scadenza.AereoNavigation.Modello,
                    Marche = scadenza.AereoNavigation.Marche,
                    MinutiPregressi = scadenza.AereoNavigation.MinutiPregressi,
                    MinutiVolo = scadenza.AereoNavigation.Voli.Sum(volo => volo.Durata),
                    IdTipoScadenza = scadenza.TipoScadenza,
                    TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
                    Risolta = scadenza.Risolta,
                    Data = scadenza.Data,
                    Minuti = scadenza.Minuti,
                    Note = scadenza.Note
                });
        }

        // GET scadenzepersone/tipi
        public IEnumerable<TipoScadenzaPersonaViewModel> GetTipiScadenzePersone()
        {
            return _contesto.TipiScadenzePersone
                .Select(tipo => new TipoScadenzaPersonaViewModel
                {
                    Id = tipo.Id,
                    Descrizione = tipo.Descrizione
                });
        }

        // GET scadenzepersone/tipi/id
        public TipoScadenzaPersonaViewModel? GetTipiScadenzePersone(long idTipoScadenzaPersona)
        {
            return _contesto.TipiScadenzePersone
                .Where(tipo => tipo.Id == idTipoScadenzaPersona)
                .Select(tipo => new TipoScadenzaPersonaViewModel
                {
                    Id = tipo.Id,
                    Descrizione = tipo.Descrizione
                }).FirstOrDefault();
        }

        // GET scadenzeaerei/tipi
        public IEnumerable<TipoScadenzaAereoViewModel> GetTipiScadenzeAerei()
        {
            return _contesto.TipiScadenzeAerei
                .Select(tipoScadenzaAereo => new TipoScadenzaAereoViewModel
                {
                    Id = tipoScadenzaAereo.Id,
                    Descrizione = tipoScadenzaAereo.Descrizione

                }).OrderBy(tipoScadenzaAereo => tipoScadenzaAereo.Id);
        }

        // GET scadenzeaerei/tipi/id
        public TipoScadenzaAereoViewModel? GetTipiScadenzeAerei(long idTipoScadenzaAereo)
        {
            return _contesto.TipiScadenzeAerei
                .Where(tipoScadenzaAereo => tipoScadenzaAereo.Id == idTipoScadenzaAereo)
                .Select(tipoScadenzaAereo => new TipoScadenzaAereoViewModel
                {
                    Id = tipoScadenzaAereo.Id,
                    Descrizione = tipoScadenzaAereo.Descrizione

                }).FirstOrDefault();
        }


        public async Task<ScadenzeAerei?> PostScadenzaAereo(ScadenzaAereoViewModel scadenzaModel)
        {
            var nuovaScadenza = new ScadenzeAerei();
            nuovaScadenza.Risolta = false;
            nuovaScadenza.Data = scadenzaModel.Data;
            nuovaScadenza.Aereo = scadenzaModel.Aereo;
            return null;


        }

    }
}
