using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class DashboardRepository: IDashboardRepository
    {
        private QTBWebDBContext _contesto;
        public DashboardRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<OreDiVoloPerPilotaViewModel> GetOreDiVoloPerPilota()
        {
            return _contesto.Persones
                .Where(persona => persona.Pilota == true)
                .Select(persona => new OreDiVoloPerPilotaViewModel
                {
                    Name = persona.Nome + " " + persona.Cognome,
                    Value = (persona.MinutiPregressi + persona.VoliPilotaNavigations.Sum(voli => voli.Durata)) / 60
                })
                .Take(5);
        }

        public IEnumerable<OreDiVoloPerAereoViewModel> GetOreDiVoloPerAereo()
        {
            return _contesto.Aereis
                .Select(aereo => new OreDiVoloPerAereoViewModel
                {
                    Name = aereo.Marche,
                    Value = (aereo.MinutiPregressi + aereo.Volis.Sum(voli => voli.Durata)) / 60
                })
                .Take(5);
        }
    }
}
