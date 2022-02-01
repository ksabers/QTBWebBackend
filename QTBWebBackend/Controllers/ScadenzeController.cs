using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using QTBWebBackend.ViewModels;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class ScadenzeController : Controller
    {
        private IScadenzeRepository _repository;

        public ScadenzeController(IScadenzeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/scadenzepersone")]
        public IActionResult GetScadenzePersone()
        {
            return Ok(_repository.GetScadenzePersone());
        }

        [HttpGet("api/scadenzeaerei")]
        public IActionResult GetScadenzeAerei()
        {
            return Ok(_repository.GetScadenzeAerei());
        }

        [HttpGet("api/scadenzepersone/{idScadenza}")]
        public IActionResult GetScadenzePersone(long idScadenza)
        {
            return Ok(_repository.GetScadenzePersone(idScadenza));
        }

        [HttpGet("api/scadenzeaerei/{idScadenza}")]
        public IActionResult GetScadenzeAerei(long idScadenza)
        {
            return Ok(_repository.GetScadenzeAerei(idScadenza));
        }

        [HttpGet("api/scadenzepersone/persona/{idPersona}")]
        public IActionResult GetScadenzePersoneDiUnaPersona(long idPersona)
        {
            return Ok(_repository.GetScadenzePersoneDiUnaPersona(idPersona));
        }

        [HttpGet("api/scadenzeaerei/persona/{idPersona}")]
        public IActionResult GetScadenzeAereiDiUnaPersona(long idPersona)
        {
            return Ok(_repository.GetScadenzeAereiDiUnaPersona(idPersona));
        }

        [HttpGet("api/scadenzeaerei/aereo/{idAereo}")]
        public IActionResult GetScadenzeAereiDiUnAereo(long idAereo)
        {
            return Ok(_repository.GetScadenzeAereiDiUnAereo(idAereo));
        }

        [HttpGet("api/scadenzepersone/tipi")]
        public IActionResult GetTipiScadenzePersone()
        {
            return Ok(_repository.GetTipiScadenzePersone());
        }

        [HttpGet("api/scadenzeaerei/tipi")]
        public IActionResult GetTipiScadenzeAerei()
        {
            return Ok(_repository.GetTipiScadenzeAerei());
        }

        [HttpGet("api/scadenzepersone/tipi/{idTipoScadenza}")]
        public IActionResult GetTipiScadenzePersone(long idTipoScadenza)
        {
            return Ok(_repository.GetTipiScadenzePersone(idTipoScadenza));
        }

        [HttpGet("api/scadenzeaerei/tipi/{idTipoScadenza}")]
        public IActionResult GetTipiScadenzeAerei(long idTipoScadenza)
        {
            return Ok(_repository.GetTipiScadenzeAerei(idTipoScadenza));
        }
    }
}
