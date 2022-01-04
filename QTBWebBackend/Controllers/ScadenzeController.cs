using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;

namespace QTBWebBackend.Controllers
{
    public class ScadenzeController : Controller
    {
        private IScadenzeRepository _repository;

        public ScadenzeController(IScadenzeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/scadenze/persone")]
        public ActionResult GetScadenze()
        {
            return Ok(_repository.GetScadenze());
        }

        [HttpGet("api/scadenze/persone/{idPersona}")]
        public ActionResult GetScadenze(long idPersona)
        {
            return Ok(_repository.GetScadenze(idPersona));
        }

        //[HttpGet("api/scadenze/persone/{numGiorni}/{idPersona}")]
        //public ActionResult GetScadenzeInScadenzaSingolaPersona(long idPersona, int numGiorni)
        //{
        //    return Ok(_repository.GetScadenzeInScadenzaSingolaPersona(idPersona, numGiorni));
        //}

        //[HttpGet("api/scadenzeaerei")]
        //public ActionResult GetScadenzeAerei()
        //{
        //    return Ok(_repository.GetScadenzeAerei());
        //}

        //[HttpGet("api/scadenzeaerei/{idScadenza}")]
        //public ActionResult GetScadenzaAereo(long idScadenza)
        //{
        //    return Ok(_repository.GetScadenzaAereo(idScadenza));
        //}

        //[HttpGet("api/scadenzepersone")]
        //public ActionResult GetScadenzePersone()
        //{
        //    return Ok(_repository.GetScadenzePersone());
        //}

        //[HttpGet("api/scadenzepersone/{idScadenza}")]
        //public ActionResult GetScadenzaPersona(long idScadenza)
        //{
        //    return Ok(_repository.GetScadenzaPersona(idScadenza));
        //}

        // GET: AereiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AereiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetScadenze));
            }
            catch
            {
                return View();
            }
        }

        // GET: AereiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AereiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetScadenze));
            }
            catch
            {
                return View();
            }
        }

        // GET: AereiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AereiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetScadenze));
            }
            catch
            {
                return View();
            }
        }
    }
}
