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
                    IdTipoManutenzione = manutenzione.Tipo,
                    TipoManutenzione = manutenzione.TipoNavigation.Descrizione,
                    Ordinaria = manutenzione.Ordinaria,
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

        public ManutenzioneViewModel? GetManutenzioni(long idManutenzione)
        {
            return _contesto.Manutenzionis
                .Where(manutenzione => manutenzione.Id == idManutenzione)
                .Select(manutenzione => new ManutenzioneViewModel
                {
                    Id = manutenzione.Id,
                    Descrizione = manutenzione.Descrizione,
                    IdTipoManutenzione = manutenzione.Tipo,
                    TipoManutenzione = manutenzione.TipoNavigation.Descrizione,
                    Ordinaria = manutenzione.Ordinaria,
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

        public IEnumerable<TipoManutenzioneViewModel> GetTipiManutenzioni()
        {
            return _contesto.TipiManutenzionis
                .Select(tipoManutenzione => new TipoManutenzioneViewModel
                {
                    Id = tipoManutenzione.Id,
                    Descrizione = tipoManutenzione.Descrizione

                }).OrderBy(tipoManutenzione => tipoManutenzione.Id);
        }

        public TipoManutenzioneViewModel? GetTipiManutenzioni(long idTipoManutenzione)
        {
            return _contesto.TipiManutenzionis
                .Where(tipoManutenzione => tipoManutenzione.Id == idTipoManutenzione)
                .Select(tipoManutenzione => new TipoManutenzioneViewModel
                {
                    Id = tipoManutenzione.Id,
                    Descrizione = tipoManutenzione.Descrizione

                }).FirstOrDefault();
        }
    }
}
