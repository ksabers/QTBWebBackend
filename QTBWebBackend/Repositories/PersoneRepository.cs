using System.Collections.Generic;
using System.Linq;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;

namespace QTBWebBackend.Repositories
{
    public class PersoneRepository: IPersoneRepository
    {
        private QTBWebDBContext _contesto;

        public PersoneRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<PersonaViewModel> GetPersone()
        {
            return _contesto.Persone
                .Select(persona => new PersonaViewModel
                {
                    Id = persona.Id,
                    Pilota = persona.Pilota,
                    Nome = persona.Nome,
                    Cognome = persona.Cognome,
                    Indirizzo = persona.Indirizzo,
                    DataNascita = persona.DataNascita,
                    LuogoNascita = persona.LuogoNascita,
                    CodiceFiscale = persona.CodiceFiscale,
                    Email = persona.Login.First().Email,
                    Citta = persona.Citta,
                    Cap = persona.Cap,
                    Telefono = persona.Telefono,
                    NumeroVoliDaPilota = persona.VoliPilotaNavigation.Count(),
                    NumeroVoliDaPasseggero = persona.VoliPasseggeroNavigation.Count(),
                    MinutiPregressi = persona.MinutiPregressi,
                    MinutiVoloDaPilota = persona.VoliPilotaNavigation.Sum(voli => voli.Durata),
                    MinutiVoloDaPasseggero = persona.VoliPasseggeroNavigation.Sum(voli => voli.Durata),
                    IdAeroportoBase = persona.AeroportoBaseNavigation.Id,
                    AeroportoBase = persona.AeroportoBaseNavigation.Nome,
                    Tessera = persona.Tessera,
                    AereiPosseduti = persona.AereiPosseduti.Select(aereo => new AereoPossedutoViewModel
                    {
                        Id = aereo.AereoNavigation.Id,
                        Costruttore = aereo.AereoNavigation.Costruttore,
                        Modello = aereo.AereoNavigation.Modello,
                        Marche = aereo.AereoNavigation.Marche,
                        QuotaProprieta = aereo.Quota

                    }).ToList()

                }).OrderBy(persona => persona.Cognome).ThenBy(persona => persona.Nome);
        }

        public PersonaViewModel? GetPersone(long idPersona)
        {
            return _contesto.Persone
                .Where(persona => persona.Id == idPersona)
                .Select(persona => new PersonaViewModel
                {
                    Id = persona.Id,
                    Pilota = persona.Pilota,
                    Nome = persona.Nome,
                    Cognome = persona.Cognome,
                    Indirizzo = persona.Indirizzo,
                    DataNascita = persona.DataNascita,
                    LuogoNascita = persona.LuogoNascita,
                    CodiceFiscale = persona.CodiceFiscale,
                    Email = persona.Login.First().Email,
                    Citta = persona.Citta,
                    Cap = persona.Cap,
                    Telefono = persona.Telefono,
                    NumeroVoliDaPilota = persona.VoliPilotaNavigation.Count(),
                    NumeroVoliDaPasseggero = persona.VoliPasseggeroNavigation.Count(),
                    MinutiPregressi = persona.MinutiPregressi,
                    MinutiVoloDaPilota = persona.VoliPilotaNavigation.Sum(voli => voli.Durata),
                    MinutiVoloDaPasseggero = persona.VoliPasseggeroNavigation.Sum(voli => voli.Durata),
                    IdAeroportoBase = persona.AeroportoBaseNavigation.Id,
                    AeroportoBase = persona.AeroportoBaseNavigation.Nome,
                    Tessera = persona.Tessera,
                    AereiPosseduti = persona.AereiPosseduti.Select(aereo => new AereoPossedutoViewModel
                    {
                        Id = aereo.AereoNavigation.Id,
                        Costruttore = aereo.AereoNavigation.Costruttore,
                        Modello = aereo.AereoNavigation.Modello,
                        Marche = aereo.AereoNavigation.Marche,
                        QuotaProprieta = aereo.Quota
                    }).ToList()
                })
                .FirstOrDefault();
        }
    }
}
