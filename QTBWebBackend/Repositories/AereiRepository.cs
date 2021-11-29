using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class AereiRepository: IAereiRepository
    {
        private QTBWebDBContext _contesto;

        public AereiRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<AereoViewModel> GetAerei()
        {
            return _contesto.Aereis
                .Select(aereo => new AereoViewModel
                {
                    Id = aereo.Id,
                    Costruttore = aereo.Costruttore,
                    Modello = aereo.Modello,
                    Marche = aereo.Marche,
                    MinutiPregressi = aereo.MinutiPregressi,
                    MinutiVolo = aereo.Volis.Sum(volo => volo.Durata),
                    VoloPiuRecente = aereo.Volis.OrderByDescending(volo => volo.OrametroOreFine * 60 + volo.OrametroMinutiFine).FirstOrDefault(),
                    Proprietari = aereo.AereiPossedutis.Select(proprietario => new ProprietarioViewModel
                    {
                        Id = proprietario.PersonaNavigation.Id,
                        Nome = proprietario.PersonaNavigation.Nome,
                        Cognome = proprietario.PersonaNavigation.Cognome,
                        QuotaProprieta = proprietario.Quota
                    }).ToList()
                }).OrderBy(aereo => aereo.Marche);
        }

        public AereoViewModel? GetAereo(long idAereo)
        {
            return _contesto.Aereis
                .Where(aereo => aereo.Id == idAereo)
                .Select(aereo => new AereoViewModel
                {
                    Id = aereo.Id,
                    Costruttore = aereo.Costruttore,
                    Modello = aereo.Modello,
                    Marche = aereo.Marche,
                    MinutiPregressi = aereo.MinutiPregressi,
                    MinutiVolo = aereo.Volis.Sum(volo => volo.Durata),
                    VoloPiuRecente = aereo.Volis.OrderByDescending(volo => volo.OrametroOreFine * 60 + volo.OrametroMinutiFine).FirstOrDefault(),
                    Proprietari = aereo.AereiPossedutis.Select(proprietario => new ProprietarioViewModel
                    {
                        Id = proprietario.PersonaNavigation.Id,
                        Nome = proprietario.PersonaNavigation.Nome,
                        Cognome = proprietario.PersonaNavigation.Cognome,
                        QuotaProprieta = proprietario.Quota
                    }).ToList()
                })
                .FirstOrDefault();
        }
    }
}
