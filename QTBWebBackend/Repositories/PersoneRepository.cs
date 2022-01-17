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
            return _contesto.Persones
                .Select(persona => new PersonaViewModel
                {
                    Id = persona.Id,
                    Pilota = persona.Pilota,
                    Nome = persona.Nome,
                    Cognome = persona.Cognome,
                    Email = persona.Logins.First().Email,
                    NumeroVoliDaPilota = persona.VoliPilotaNavigations.Count(),
                    NumeroVoliDaPasseggero = persona.VoliPasseggeroNavigations.Count(),
                    MinutiPregressi = persona.MinutiPregressi,
                    MinutiVoloDaPilota = persona.VoliPilotaNavigations.Sum(voli => voli.Durata),
                    MinutiVoloDaPasseggero = persona.VoliPasseggeroNavigations.Sum(voli => voli.Durata),
                    IdAeroportoBase = persona.AeroportoBaseNavigation.Id,
                    AeroportoBase = persona.AeroportoBaseNavigation.Nome,
                    Tessera = persona.Tessera,
                    AereiPosseduti = persona.AereiPossedutis.Select(aereo => new AereoPossedutoViewModel
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
            return _contesto.Persones
                .Where(persona => persona.Id == idPersona)
                .Select(persona => new PersonaViewModel
                {
                    Id = persona.Id,
                    Pilota = persona.Pilota,
                    Nome = persona.Nome,
                    Cognome = persona.Cognome,
                    Email = persona.Logins.First().Email,
                    NumeroVoliDaPilota = persona.VoliPilotaNavigations.Count(),
                    NumeroVoliDaPasseggero = persona.VoliPasseggeroNavigations.Count(),
                    MinutiPregressi = persona.MinutiPregressi,
                    MinutiVoloDaPilota = persona.VoliPilotaNavigations.Sum(voli => voli.Durata),
                    MinutiVoloDaPasseggero = persona.VoliPasseggeroNavigations.Sum(voli => voli.Durata),
                    IdAeroportoBase = persona.AeroportoBaseNavigation.Id,
                    AeroportoBase = persona.AeroportoBaseNavigation.Nome,
                    Tessera = persona.Tessera,
                    AereiPosseduti = persona.AereiPossedutis.Select(aereo => new AereoPossedutoViewModel
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
