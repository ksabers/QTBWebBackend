using System.ComponentModel.DataAnnotations;

namespace QTBWebBackend.ViewModels
{
    public class TipoManutenzioneViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required] 
        public string? Descrizione { get; set; }

    }
}
