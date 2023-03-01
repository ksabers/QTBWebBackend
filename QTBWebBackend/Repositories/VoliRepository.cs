using Microsoft.EntityFrameworkCore;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.Repositories
{
    public class VoliRepository: IVoliRepository
    {
        private QTBWebDBContext _contesto;
        public VoliRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<VoloViewModel> GetVoli()
        {
            return _contesto.Voli
                .Select(volo => new VoloViewModel
                {
                    Id = volo.Id,
                    Descrizione = volo.Descrizione,
                    IdTipoVolo = volo.Tipo,
                    TipoVolo = volo.TipoNavigation.Descrizione,
                    IdAereo = volo.Aereo,
                    Modello = volo.AereoNavigation.Modello,
                    Marche = volo.AereoNavigation.Marche,
                    PesoVuoto = volo.AereoNavigation.PesoVuoto,
                    IdPilota = volo.Pilota,
                    NomePilota = volo.PilotaNavigation.Nome,
                    CognomePilota = volo.PilotaNavigation.Cognome,
                    IdPasseggero = volo.Passeggero,
                    NomePasseggero = volo.PasseggeroNavigation.Nome,
                    CognomePasseggero = volo.PasseggeroNavigation.Cognome,
                    OraInizio = volo.OraInizio,
                    OraLocaleDecollo = volo.OraLocaleDecollo,
                    OrametroOreInizio = volo.OrametroOreInizio,
                    OrametroMinutiInizio = volo.OrametroMinutiInizio,
                    OraFine = volo.OraFine,
                    OraLocaleAtterraggio = volo.OraLocaleAtterraggio,
                    OrametroOreFine = volo.OrametroOreFine,
                    OrametroMinutiFine = volo.OrametroMinutiFine,
                    Durata = volo.Durata,
                    CarburanteInizialeSx = volo.CarburanteInizialeSx,
                    CarburanteInizialeDx = volo.CarburanteInizialeDx,
                    CarburanteAggiuntoSx = volo.CarburanteAggiuntoSx,
                    CarburanteAggiuntoDx = volo.CarburanteAggiuntoDx,
                    Olio = volo.Olio,
                    PesoOccupanti = volo.PesoOccupanti,
                    Bagaglio = volo.Bagaglio,
                    IdAeroportoInizio = volo.AeroportoInizio,
                    AeroportoInizio = volo.AeroportoInizioNavigation.Nome,
                    CoordinateInizio = volo.AeroportoInizioNavigation.Coordinate,
                    IdAeroportoFine = volo.AeroportoFine,
                    AeroportoFine = volo.AeroportoFineNavigation.Nome,
                    CoordinateFine = volo.AeroportoFineNavigation.Coordinate
                }).OrderByDescending(volo => volo.OraFine).ThenByDescending(volo => volo.Id);
        }

        public IEnumerable<VoloViewModel> GetVoliDiUnAereo(long idAereo)
        {
            return _contesto.Voli
                .Where(volo => volo.Aereo == idAereo)
                .Select(volo => new VoloViewModel
                {
                    Id = volo.Id,
                    Descrizione = volo.Descrizione,
                    IdTipoVolo = volo.Tipo,
                    TipoVolo = volo.TipoNavigation.Descrizione,
                    IdAereo = volo.Aereo,
                    Modello = volo.AereoNavigation.Modello,
                    Marche = volo.AereoNavigation.Marche,
                    PesoVuoto = volo.AereoNavigation.PesoVuoto,
                    IdPilota = volo.Pilota,
                    NomePilota = volo.PilotaNavigation.Nome,
                    CognomePilota = volo.PilotaNavigation.Cognome,
                    IdPasseggero = volo.Passeggero,
                    NomePasseggero = volo.PasseggeroNavigation.Nome,
                    CognomePasseggero = volo.PasseggeroNavigation.Cognome,
                    OraInizio = volo.OraInizio,
                    OraLocaleDecollo = volo.OraLocaleDecollo,
                    OrametroOreInizio = volo.OrametroOreInizio,
                    OrametroMinutiInizio = volo.OrametroMinutiInizio,
                    OraFine = volo.OraFine,
                    OraLocaleAtterraggio = volo.OraLocaleAtterraggio,
                    OrametroOreFine = volo.OrametroOreFine,
                    OrametroMinutiFine = volo.OrametroMinutiFine,
                    Durata = volo.Durata,
                    CarburanteInizialeSx = volo.CarburanteInizialeSx,
                    CarburanteInizialeDx = volo.CarburanteInizialeDx,
                    CarburanteAggiuntoSx = volo.CarburanteAggiuntoSx,
                    CarburanteAggiuntoDx = volo.CarburanteAggiuntoDx,
                    Olio = volo.Olio,
                    PesoOccupanti = volo.PesoOccupanti,
                    Bagaglio = volo.Bagaglio,
                    IdAeroportoInizio = volo.AeroportoInizio,
                    AeroportoInizio = volo.AeroportoInizioNavigation.Nome,
                    CoordinateInizio = volo.AeroportoInizioNavigation.Coordinate,
                    IdAeroportoFine = volo.AeroportoFine,
                    AeroportoFine = volo.AeroportoFineNavigation.Nome,
                    CoordinateFine = volo.AeroportoFineNavigation.Coordinate
                }).OrderByDescending(volo => volo.OraFine).ThenByDescending(volo => volo.Id);
        }

        public VoloViewModel? GetVoli(long idVolo)
        {
            return _contesto.Voli
                .Where(volo => volo.Id == idVolo)
                .Select(volo => new VoloViewModel
                {
                    Id = volo.Id,
                    Descrizione = volo.Descrizione,
                    IdTipoVolo = volo.Tipo,
                    TipoVolo = volo.TipoNavigation.Descrizione,
                    IdAereo =volo.Aereo,
                    Modello = volo.AereoNavigation.Modello,
                    Marche = volo.AereoNavigation.Marche,
                    PesoVuoto = volo.AereoNavigation.PesoVuoto,
                    IdPilota = volo.Pilota,
                    NomePilota = volo.PilotaNavigation.Nome,
                    CognomePilota = volo.PilotaNavigation.Cognome,
                    IdPasseggero = volo.Passeggero,
                    NomePasseggero = volo.PasseggeroNavigation.Nome,
                    CognomePasseggero = volo.PasseggeroNavigation.Cognome,
                    OraInizio = volo.OraInizio,
                    OraLocaleDecollo = volo.OraLocaleDecollo,
                    OrametroOreInizio = volo.OrametroOreInizio,
                    OrametroMinutiInizio = volo.OrametroMinutiInizio,
                    OraFine = volo.OraFine,
                    OraLocaleAtterraggio = volo.OraLocaleAtterraggio,
                    OrametroOreFine = volo.OrametroOreFine,
                    OrametroMinutiFine = volo.OrametroMinutiFine,
                    Durata = volo.Durata,
                    CarburanteInizialeSx = volo.CarburanteInizialeSx,
                    CarburanteInizialeDx = volo.CarburanteInizialeDx,
                    CarburanteAggiuntoSx = volo.CarburanteAggiuntoSx,
                    CarburanteAggiuntoDx = volo.CarburanteAggiuntoDx,
                    Olio = volo.Olio,
                    PesoOccupanti = volo.PesoOccupanti,
                    Bagaglio = volo.Bagaglio,
                    IdAeroportoInizio = volo.AeroportoInizio,
                    AeroportoInizio = volo.AeroportoInizioNavigation.Nome,
                    CoordinateInizio = volo.AeroportoInizioNavigation.Coordinate,
                    IdAeroportoFine = volo.AeroportoFine,
                    AeroportoFine = volo.AeroportoFineNavigation.Nome,
                    CoordinateFine = volo.AeroportoFineNavigation.Coordinate
                })
                .FirstOrDefault();
        }

        public IEnumerable<TipoVoloViewModel> GetTipiVoli()
        {
            return _contesto.TipiVoli
                .Select(tipoVolo => new TipoVoloViewModel
                {
                    Id = tipoVolo.Id,
                    Descrizione = tipoVolo.Descrizione

                }).OrderBy(tipoVolo => tipoVolo.Id);
        }

        public TipoVoloViewModel? GetTipiVoli(long idTipoVolo)
        {
            return _contesto.TipiVoli
                .Where(tipoVolo => tipoVolo.Id == idTipoVolo)
                .Select(tipoVolo => new TipoVoloViewModel
                {
                    Id = tipoVolo.Id,
                    Descrizione = tipoVolo.Descrizione

                }).FirstOrDefault();
        }

        public async Task<Voli?> PostVolo(VoloViewModel voloModel)
        {
            var nuovoVolo = new Voli();

            nuovoVolo.Descrizione = voloModel.Descrizione;
            nuovoVolo.Tipo = voloModel.IdTipoVolo;
            nuovoVolo.Aereo = voloModel.IdAereo;
            nuovoVolo.Pilota = voloModel.IdPilota;
            nuovoVolo.Passeggero = voloModel.IdPasseggero;
            nuovoVolo.OrametroOreInizio = voloModel.OrametroOreInizio;
            nuovoVolo.OrametroMinutiInizio = voloModel.OrametroMinutiInizio;
            nuovoVolo.OraLocaleDecollo = voloModel.OraLocaleDecollo;
            nuovoVolo.OraFine = voloModel.OraFine;
            nuovoVolo.OraLocaleAtterraggio = voloModel.OraLocaleAtterraggio;
            nuovoVolo.OrametroOreFine = voloModel.OrametroOreFine;
            nuovoVolo.OrametroMinutiFine = voloModel.OrametroMinutiFine;
            nuovoVolo.CarburanteInizialeSx = voloModel.CarburanteInizialeSx;
            nuovoVolo.CarburanteInizialeDx = voloModel.CarburanteInizialeDx;
            nuovoVolo.CarburanteAggiuntoSx = voloModel.CarburanteAggiuntoSx;
            nuovoVolo.CarburanteAggiuntoDx = voloModel.CarburanteAggiuntoDx;
            nuovoVolo.Olio = voloModel.Olio;
            nuovoVolo.PesoOccupanti = voloModel.PesoOccupanti;
            nuovoVolo.Bagaglio = voloModel.Bagaglio;
            nuovoVolo.AeroportoInizio = voloModel.IdAeroportoInizio;
            nuovoVolo.AeroportoFine = voloModel.IdAeroportoFine;

            try
            {
                _contesto.Add(nuovoVolo);
                if ((await _contesto.SaveChangesAsync()) > 0)
                {
                    return nuovoVolo;
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }
    }
}
