using Microsoft.EntityFrameworkCore;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.Repositories
{
    public class ScadenzeRepository : IScadenzeRepository
    {
        private QTBWebDBContext _contesto;

        public ScadenzeRepository(QTBWebDBContext contesto)
        {
            _contesto = contesto;
        }

        public IEnumerable<ScadenzeViewModel> GetScadenze()
        {
            return _contesto.Persones
                .Select(persona => new ScadenzeViewModel
                {
                    Persona = persona.Id,
                    Nome = persona.Nome,
                    Cognome = persona.Cognome,
                    MinutiPregressi = persona.MinutiPregressi,
                    MinutiVoloDaPilota = persona.VoliPilotaNavigations.Sum(voli => voli.Durata),
                    ScadenzePersona = persona.ScadenzePersones
                    .Where(scadenza => scadenza.Risolta == false)
                    .Select(scadenza => new SingolaScadenzaGenericaViewModel
                    {
                        Id = scadenza.Id,
                        Tipo = scadenza.TipoScadenzaNavigation.Descrizione,
                        Data = scadenza.Data,
                        Minuti = scadenza.Minuti,
                        Note = scadenza.Note
                    }).ToArray(),
                    ScadenzeAerei = persona.AereiPossedutis.Select(aereo => new ScadenzeDiUnAereoViewModel
                    {
                        Aereo = aereo.AereoNavigation.Id,
                        Modello = aereo.AereoNavigation.Modello,
                        Marche = aereo.AereoNavigation.Marche,
                        MinutiPregressi = aereo.AereoNavigation.MinutiPregressi,
                        MinutiVolo = aereo.AereoNavigation.Volis.Sum(volo => volo.Durata),
                        ScadenzeAereo = aereo.AereoNavigation.ScadenzeAereis
                        .Where(scadenza => scadenza.Risolta == false)
                        .Select(scadenza => new SingolaScadenzaGenericaViewModel
                        {
                            Id = scadenza.Id,
                            Tipo = scadenza.TipoScadenzaNavigation.Descrizione,
                            Data = scadenza.Data,
                            Minuti = scadenza.Minuti,
                            Note = scadenza.Note
                        }).ToArray()
                    }).ToArray()
                });
        }

        public ScadenzeViewModel? GetScadenze(long idPersona)
        {
            return _contesto.Persones
                .Where(persona => persona.Id == idPersona)
                .Select(persona => new ScadenzeViewModel
                {
                    Persona = persona.Id,
                    Nome = persona.Nome,
                    Cognome = persona.Cognome,
                    MinutiPregressi = persona.MinutiPregressi,
                    MinutiVoloDaPilota = persona.VoliPilotaNavigations.Sum(voli => voli.Durata),
                    ScadenzePersona = persona.ScadenzePersones
                    .Where(scadenza => scadenza.Risolta == false)
                    .Select(scadenza => new SingolaScadenzaGenericaViewModel
                    {
                        Id = scadenza.Id,
                        Tipo = scadenza.TipoScadenzaNavigation.Descrizione,
                        Data = scadenza.Data,
                        Minuti = scadenza.Minuti,
                        Note = scadenza.Note
                    }).ToArray(),
                    ScadenzeAerei = persona.AereiPossedutis.Select(aereo => new ScadenzeDiUnAereoViewModel
                    {
                        Aereo = aereo.AereoNavigation.Id,
                        Modello = aereo.AereoNavigation.Modello,
                        Marche = aereo.AereoNavigation.Marche,
                        MinutiPregressi = aereo.AereoNavigation.MinutiPregressi,
                        MinutiVolo = aereo.AereoNavigation.Volis.Sum(volo => volo.Durata),
                        ScadenzeAereo = aereo.AereoNavigation.ScadenzeAereis
                        .Where(scadenza => scadenza.Risolta == false)
                        .Select(scadenza => new SingolaScadenzaGenericaViewModel
                        {
                            Id = scadenza.Id,
                            Tipo = scadenza.TipoScadenzaNavigation.Descrizione,
                            Data = scadenza.Data,
                            Minuti = scadenza.Minuti,
                            Note = scadenza.Note
                        }).ToArray()
                    }).ToArray()
                }).FirstOrDefault();
        }

        public async Task<ScadenzeAerei?> PostScadenzaAereo(ScadenzaAereoViewModel scadenzaModel)
        {
            var nuovaScadenza = new ScadenzeAerei();
            nuovaScadenza.Risolta = false;
            nuovaScadenza.Data = scadenzaModel.Data;
            nuovaScadenza.Aereo = scadenzaModel.Aereo;
            return null;


        }

        //public ScadenzeViewModel? GetScadenzeInScadenzaSingolaPersona(long idPersona, int giorni)
        //{
        //    System.DateTime oggi = System.DateTime.Today;
        //    return _contesto.Persones
        //        .Where(persona => persona.Id == idPersona)
        //        .Select(persona => new ScadenzeViewModel
        //        {
        //            Persona = persona.Id,
        //            Nome = persona.Nome,
        //            Cognome = persona.Cognome,
        //            ScadenzePersona = persona.ScadenzePersones
        //            .Where(scadenza => (scadenza.Risolta == false) && (EF.Functions.DateDiffDay(System.DateTime.Today, scadenza.Data)  <= giorni))
        //            .Select(scadenza => new SingolaScadenzaGenericaViewModel
        //            {
        //                Id = scadenza.Id,
        //                Tipo = scadenza.TipoScadenzaNavigation.Descrizione,
        //                Data = scadenza.Data,
        //                Note = scadenza.Note
        //            }).ToArray(),
        //            ScadenzeAerei = persona.AereiPossedutis.Select(aereo => new ScadenzeDiUnAereoViewModel
        //            {
        //                Aereo = aereo.AereoNavigation.Id,
        //                Modello = aereo.AereoNavigation.Modello,
        //                Marche = aereo.AereoNavigation.Marche,
        //                MinutiPregressi = aereo.AereoNavigation.MinutiPregressi,
        //                MinutiVolo = aereo.AereoNavigation.Volis.Sum(volo => volo.Durata),
        //                ScadenzeAereo = aereo.AereoNavigation.ScadenzeAereis
        //                .Where(scadenza => (scadenza.Risolta == false) && (EF.Functions.DateDiffDay(System.DateTime.Today, scadenza.Data) <= giorni))
        //                .Select(scadenza => new SingolaScadenzaGenericaViewModel
        //                {
        //                    Id = scadenza.Id,
        //                    Tipo = scadenza.TipoScadenzaNavigation.Descrizione,
        //                    Data = scadenza.Data,
        //                    Note = scadenza.Note
        //                }).ToArray()
        //            }).ToArray()
        //        }).FirstOrDefault();
        //}


        //public IEnumerable<ScadenzaAereoViewModel> GetScadenzeAerei()
        //{
        //    return _contesto.ScadenzeAereis
        //        .Select(scadenza => new ScadenzaAereoViewModel
        //        {
        //            Id = scadenza.Id,
        //            Aereo = scadenza.Aereo,
        //            Modello = scadenza.AereoNavigation.Modello,
        //            Marche = scadenza.AereoNavigation.Marche,
        //            MinutiPregressi = scadenza.AereoNavigation.MinutiPregressi,
        //            MinutiVolo = scadenza.AereoNavigation.Volis.Sum(volo => volo.Durata),
        //            IdTipoScadenza = scadenza.TipoScadenza,
        //            TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
        //            Risolta = scadenza.Risolta,
        //            Note = scadenza.Note
        //        });
        //}

        //public ScadenzaAereoViewModel? GetScadenzaAereo(long idScadenza)
        //{
        //    return _contesto.ScadenzeAereis
        //        .Where(scadenza => scadenza.Id == idScadenza)
        //        .Select(scadenza => new ScadenzaAereoViewModel
        //        {
        //            Id = scadenza.Id,
        //            Aereo = scadenza.Aereo,
        //            Modello = scadenza.AereoNavigation.Modello,
        //            Marche = scadenza.AereoNavigation.Marche,
        //            MinutiPregressi = scadenza.AereoNavigation.MinutiPregressi,
        //            MinutiVolo = scadenza.AereoNavigation.Volis.Sum(volo => volo.Durata),
        //            IdTipoScadenza = scadenza.TipoScadenza,
        //            TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
        //            Risolta = scadenza.Risolta,
        //            Note = scadenza.Note
        //        }).FirstOrDefault();
        //}

        //public IEnumerable<ScadenzaPersonaViewModel> GetScadenzePersone()
        //{
        //    return _contesto.ScadenzePersones
        //        .Select(scadenza => new ScadenzaPersonaViewModel
        //        {
        //            Id = scadenza.Id,
        //            Persona = scadenza.Persona,
        //            Nome = scadenza.PersonaNavigation.Nome,
        //            Cognome = scadenza.PersonaNavigation.Cognome,
        //            IdTipoScadenza = scadenza.TipoScadenza,
        //            TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
        //            Risolta = scadenza.Risolta,
        //            Note = scadenza.Note
        //        });
        //}

        //public ScadenzaPersonaViewModel? GetScadenzaPersona(long idScadenza)
        //{
        //    return _contesto.ScadenzePersones
        //        .Where(scadenza => scadenza.Id == idScadenza)
        //        .Select(scadenza => new ScadenzaPersonaViewModel
        //        {
        //            Id = scadenza.Id,
        //            Persona = scadenza.Persona,
        //            Nome = scadenza.PersonaNavigation.Nome,
        //            Cognome = scadenza.PersonaNavigation.Cognome,
        //            IdTipoScadenza = scadenza.TipoScadenza,
        //            TipoScadenza = scadenza.TipoScadenzaNavigation.Descrizione,
        //            Risolta = scadenza.Risolta,
        //            Note = scadenza.Note
        //        }).FirstOrDefault();
        //}
    }
}
