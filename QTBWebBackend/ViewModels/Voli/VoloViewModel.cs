using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class VoloViewModel
    {
        public long Id { get; set; }
        public string? Descrizione { get; set; }
        public long IdAereo { get; set; }
        public string? Modello { get; set; }
        public string? Marche { get; set; }
        public int? PesoVuoto { get; set; }
        public long IdPilota { get; set; }
        public string? NomePilota { get; set; }
        public string? CognomePilota { get; set; }
        public long? IdPasseggero { get; set; }
        public string? NomePasseggero { get; set; }
        public string? CognomePasseggero { get; set; }
        public DateTime? OraInizio { get; set; }
        public string? OraLocaleDecollo { get; set; }
        public int OrametroOreInizio { get; set; }
        public int OrametroMinutiInizio { get; set; }
        public DateTime OraFine { get; set; }
        public string? OraLocaleAtterraggio { get; set; }
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
        public long IdAeroportoInizio { get; set; }
        public string? AeroportoInizio { get; set; }
        public string? CoordinateInizio { get; set; }
        public long IdAeroportoFine { get; set; }
        public string? AeroportoFine { get; set; }
        public string? CoordinateFine { get; set; }
    }
}
