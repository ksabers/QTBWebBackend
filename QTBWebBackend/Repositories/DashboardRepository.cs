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
                });
        }

        public IEnumerable<OreDiVoloPerAereoViewModel> GetOreDiVoloPerAereo()
        {
            return _contesto.Aereis
                .Select(aereo => new OreDiVoloPerAereoViewModel
                {
                    Name = aereo.Marche,
                    Value = (aereo.MinutiPregressi + aereo.Volis.Sum(voli => voli.Durata)) / 60
                });
        }

        // Questa nella select interna avrebbe dovuto ritornare un .GroupBy(anno, mese) con un .Sum(carburante)
        // ma con EF Core dalla 5 in poi non è più consentito perché non riesce a costruire correttamente la query
        // quindi ritorniamo i voli non raggruppati e poi facciamo il raggruppamento lato client
        public IEnumerable<ConsumoAerei> GetCarburanteAnnualePerAereo()
        {
            return _contesto.Aereis
                .Select(aereo => new ConsumoAerei
                {
                    Marche = aereo.Marche,
                    Voli = aereo.Volis
                           .Select(volo => new ConsumoVoli
                           {
                               Data = volo.OraFine,
                               Consumo = volo.CarburanteAggiuntoSx + volo.CarburanteAggiuntoDx
                           }).ToArray()
                });
        }
    }
}
