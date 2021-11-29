using QTBWebBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class ManutenzioneViewModel
    {
        public long Id { get; set; }
        public string? Descrizione { get; set; }
        public DateTime Data { get; set; }
        public long Aereo { get; set; }
        public string? Modello { get; set; }
        public string? Marche { get; set; }
        public long? Persona { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public long? Volo { get; set; }


    }
}
