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
            return _contesto.Aerei
                .Select(aereo => new AereoViewModel
                {
                    Id = aereo.Id,
                    Costruttore = aereo.Costruttore,
                    Modello = aereo.Modello,
                    Marche = aereo.Marche,
                    MinutiPregressi = aereo.MinutiPregressi,
                    MinutiVolo = aereo.Voli.Sum(volo => volo.Durata),
                    PesoVuoto = aereo.PesoVuoto,
                    VoloPiuRecente = aereo.Voli.OrderByDescending(volo => volo.OrametroOreFine * 60 + volo.OrametroMinutiFine).FirstOrDefault(),
                    Proprietari = aereo.AereiPosseduti.Select(proprietario => new ProprietarioViewModel
                    {
                        Id = proprietario.PersonaNavigation.Id,
                        Nome = proprietario.PersonaNavigation.Nome,
                        Cognome = proprietario.PersonaNavigation.Cognome,
                        QuotaProprieta = proprietario.Quota
                    }).ToList()
                }).OrderBy(aereo => aereo.Marche);
        }

        public AereoViewModel? GetAerei(long idAereo)
        {
            return _contesto.Aerei
                .Where(aereo => aereo.Id == idAereo)
                .Select(aereo => new AereoViewModel
                {
                    Id = aereo.Id,
                    Costruttore = aereo.Costruttore,
                    Modello = aereo.Modello,
                    Marche = aereo.Marche,
                    MinutiPregressi = aereo.MinutiPregressi,
                    MinutiVolo = aereo.Voli.Sum(volo => volo.Durata),
                    PesoVuoto = aereo.PesoVuoto,
                    VoloPiuRecente = aereo.Voli.OrderByDescending(volo => volo.OrametroOreFine * 60 + volo.OrametroMinutiFine).FirstOrDefault(),
                    Proprietari = aereo.AereiPosseduti.Select(proprietario => new ProprietarioViewModel
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
