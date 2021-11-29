using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace QTBWebBackend.Repositories
{
    public class ManutenzioniRepository: IManutenzioniRepository
    {
        private QTBWebDBContext _contesto;
        public ManutenzioniRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<ManutenzioneViewModel> GetManutenzioni()
        {
            return _contesto.Manutenzionis
                .Select(manutenzione => new ManutenzioneViewModel
                {
                    Id = manutenzione.Id,
                    Descrizione = manutenzione.Descrizione,
                    Data = manutenzione.Data,
                    Aereo = manutenzione.Aereo,
                    Modello = manutenzione.AereoNavigation.Modello,
                    Marche = manutenzione.AereoNavigation.Marche,
                    Persona = manutenzione.Persona,
                    Nome = manutenzione.PersonaNavigation.Nome,
                    Cognome = manutenzione.PersonaNavigation.Cognome,
                    Volo = manutenzione.Volo
                }).OrderByDescending(manutenzione => manutenzione.Data);
        }

        public ManutenzioneViewModel? GetManutenzione(long idManutenzione)
        {
            return _contesto.Manutenzionis
                .Where(manutenzione => manutenzione.Id == idManutenzione)
                .Select(manutenzione => new ManutenzioneViewModel
                {
                    Id = manutenzione.Id,
                    Descrizione = manutenzione.Descrizione,
                    Data = manutenzione.Data,
                    Aereo = manutenzione.Aereo,
                    Modello = manutenzione.AereoNavigation.Modello,
                    Marche = manutenzione.AereoNavigation.Marche,
                    Persona = manutenzione.Persona,
                    Nome = manutenzione.PersonaNavigation.Nome,
                    Cognome = manutenzione.PersonaNavigation.Cognome,
                    Volo = manutenzione.Volo
                }).FirstOrDefault();
        }
    }
}
