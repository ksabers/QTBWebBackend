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
            return _contesto.Volis
                .Select(volo => new VoloViewModel
                {
                    Id = volo.Id,
                    Descrizione = volo.Descrizione,
                    IdAereo = volo.Aereo,
                    Modello = volo.AereoNavigation.Modello,
                    Marche = volo.AereoNavigation.Marche,
                    IdPilota = volo.PilotaNavigation.Id,
                    NomePilota = volo.PilotaNavigation.Nome,
                    CognomePilota = volo.PilotaNavigation.Cognome,
                    IdPasseggero = volo.PasseggeroNavigation.Id,
                    NomePasseggero = volo.PasseggeroNavigation.Nome,
                    CognomePasseggero = volo.PasseggeroNavigation.Cognome,
                    OraInizio = volo.OraInizio,
                    OrametroOreInizio = volo.OrametroOreInizio,
                    OrametroMinutiInizio = volo.OrametroMinutiInizio,
                    OraFine = volo.OraFine,
                    OrametroOreFine = volo.OrametroOreFine,
                    OrametroMinutiFine = volo.OrametroMinutiFine,
                    Durata = volo.Durata,
                    CarburanteInizialeSx = volo.CarburanteInizialeSx,
                    CarburanteInizialeDx = volo.CarburanteInizialeDx,
                    CarburanteAggiuntoSx = volo.CarburanteAggiuntoSx,
                    CarburanteAggiuntoDx = volo.CarburanteAggiuntoDx,
                    Olio = volo.Olio,
                    IdAeroportoInizio = volo.AeroportoInizioNavigation.Id,
                    AeroportoInizio = volo.AeroportoInizioNavigation.Nome,
                    IdAeroportoFine = volo.AeroportoFineNavigation.Id,
                    AeroportoFine = volo.AeroportoFineNavigation.Nome
                });
        }

        public VoloViewModel? GetVolo(long idVolo)
        {
            return _contesto.Volis
                .Where(volo => volo.Id == idVolo)
                .Select(volo => new VoloViewModel
                {
                    Id = volo.Id,
                    Descrizione = volo.Descrizione,
                    IdAereo =volo.Aereo,
                    Modello = volo.AereoNavigation.Modello,
                    Marche = volo.AereoNavigation.Marche,
                    IdPilota = volo.PilotaNavigation.Id,
                    NomePilota = volo.PilotaNavigation.Nome,
                    CognomePilota = volo.PilotaNavigation.Cognome,
                    IdPasseggero = volo.PasseggeroNavigation.Id,
                    NomePasseggero = volo.PasseggeroNavigation.Nome,
                    CognomePasseggero = volo.PasseggeroNavigation.Cognome,
                    OraInizio = volo.OraInizio,
                    OrametroOreInizio = volo.OrametroOreInizio,
                    OrametroMinutiInizio = volo.OrametroMinutiInizio,
                    OraFine = volo.OraFine,
                    OrametroOreFine = volo.OrametroOreFine,
                    OrametroMinutiFine = volo.OrametroMinutiFine,
                    Durata = volo.Durata,
                    CarburanteInizialeSx = volo.CarburanteInizialeSx,
                    CarburanteInizialeDx = volo.CarburanteInizialeDx,
                    CarburanteAggiuntoSx = volo.CarburanteAggiuntoSx,
                    CarburanteAggiuntoDx = volo.CarburanteAggiuntoDx,
                    Olio = volo.Olio,
                    IdAeroportoInizio = volo.AeroportoInizioNavigation.Id,
                    AeroportoInizio = volo.AeroportoInizioNavigation.Nome,
                    IdAeroportoFine = volo.AeroportoFineNavigation.Id,
                    AeroportoFine = volo.AeroportoFineNavigation.Nome
                })
                .FirstOrDefault();
        }

        public async Task<bool> PostVolo(VoloViewModel voloModel)
        {
            var nuovoVolo = new Voli();

            nuovoVolo.Descrizione = voloModel.Descrizione;
            nuovoVolo.Aereo = voloModel.IdAereo;
            nuovoVolo.Pilota = voloModel.IdPilota;
            nuovoVolo.Passeggero = voloModel.IdPasseggero;
            nuovoVolo.OrametroOreInizio = voloModel.OrametroOreInizio;
            nuovoVolo.OrametroMinutiInizio = voloModel.OrametroMinutiInizio;
            nuovoVolo.OraFine = voloModel.OraFine;
            nuovoVolo.OrametroOreFine = voloModel.OrametroOreFine;
            nuovoVolo.OrametroMinutiFine = voloModel.OrametroMinutiFine;
            nuovoVolo.CarburanteInizialeSx = voloModel.CarburanteInizialeSx;
            nuovoVolo.CarburanteInizialeDx = voloModel.CarburanteInizialeDx;
            nuovoVolo.CarburanteAggiuntoSx = voloModel.CarburanteAggiuntoSx;
            nuovoVolo.CarburanteAggiuntoDx = voloModel.CarburanteAggiuntoDx;
            nuovoVolo.Olio = voloModel.Olio;
            nuovoVolo.AeroportoInizio = voloModel.IdAeroportoInizio;
            nuovoVolo.AeroportoFine = voloModel.IdAeroportoFine;

            try
            {
                _contesto.Add(nuovoVolo);
                return (await _contesto.SaveChangesAsync()) > 0;
            }
            catch (DbUpdateException)
            {
                return false;
            }

        }
    }
}
