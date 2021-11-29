using QTBWebBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.ViewModels
{
    public class AeroportoViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Identificativo { get; set; }

        [Required]
        public string? Coordinate { get; set; }

    }
}
