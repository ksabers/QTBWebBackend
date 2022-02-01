using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class VoliController : Controller
    {
        private IVoliRepository _repository;

        public VoliController(IVoliRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/voli")]
        public IActionResult GetVoli()
        {
            return Ok(_repository.GetVoli());
        }

        [HttpGet("api/voli/aerei/{idAereo}")]
        public IActionResult GetVoliDiUnAereo(long idAereo)
        {
            return Ok(_repository.GetVoliDiUnAereo(idAereo));
        }

        [HttpGet("api/voli/{idVolo}")]
        public IActionResult GetVoli(long idVolo)
        {
            return Ok(_repository.GetVoli(idVolo));
        }

        [HttpGet("api/voli/tipi")]
        public IActionResult GetTipiVoli()
        {
            return Ok(_repository.GetTipiVoli());
        }

        [HttpGet("api/voli/tipi/{idTipoVolo}")]
        public IActionResult GetTipiVoli(long idTipoVolo)
        {
            return Ok(_repository.GetTipiVoli(idTipoVolo));
        }

        [HttpPost("api/voli")]
        public async Task<IActionResult> PostVolo([FromBody] VoloViewModel volo)
        {
            Voli? voloCreato = await _repository.PostVolo(volo);
            if (voloCreato != null)
            {
                return Created($"api/voli/{voloCreato.Id}", voloCreato);
            }
            else
            {
                return BadRequest("Errore");
            }
        }
    }
}