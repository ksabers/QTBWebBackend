using System;
using System.Collections.Generic;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class Voli
    {
        public Voli()
        {
            Manutenzionis = new HashSet<Manutenzioni>();
        }

        public long Id { get; set; }
        public string Descrizione { get; set; }
        public long Pilota { get; set; }
        public long? Passeggero { get; set; }
        public long Aereo { get; set; }
        public DateTime? OraInizio { get; set; }
        public string OraLocaleDecollo { get; set; }
        public int OrametroOreInizio { get; set; }
        public int OrametroMinutiInizio { get; set; }
        public DateTime OraFine { get; set; }
        public string OraLocaleAtterraggio { get; set; }
        public int OrametroOreFine { get; set; }
        public int OrametroMinutiFine { get; set; }
        public int? Durata { get; set; }
        public int? CarburanteInizialeSx { get; set; }
        public int? CarburanteInizialeDx { get; set; }
        public int? CarburanteAggiuntoSx { get; set; }
        public int? CarburanteAggiuntoDx { get; set; }
        public int? Olio { get; set; }
        public int? PesoOccupanti { get; set; }
        public int? Bagaglio { get; set; }
        public long AeroportoInizio { get; set; }
        public long AeroportoFine { get; set; }

        public virtual Aerei AereoNavigation { get; set; }
        public virtual Aeroporti AeroportoFineNavigation { get; set; }
        public virtual Aeroporti AeroportoInizioNavigation { get; set; }
        public virtual Persone PasseggeroNavigation { get; set; }
        public virtual Persone PilotaNavigation { get; set; }
        public virtual ICollection<Manutenzioni> Manutenzionis { get; set; }
    }
}
