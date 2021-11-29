using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;

namespace QTBWebBackend.Controllers
{
    public class DashboardController : Controller
    {
        private IDashboardRepository _repository;

        public DashboardController(IDashboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/dashboard/oredivolopiloti")]
        public ActionResult GetOreDiVoloPerPilota()
        {
            return Ok(_repository.GetOreDiVoloPerPilota());
        }

        [HttpGet("api/dashboard/oredivoloaerei")]
        public ActionResult GetOreDiVoloPerAereo()
        {
            return Ok(_repository.GetOreDiVoloPerAereo());
        }













    }
}
