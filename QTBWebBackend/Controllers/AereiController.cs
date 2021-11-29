using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;

namespace QTBWebBackend.Controllers
{
    public class AereiController : Controller
    {
        private IAereiRepository _repository;

        public AereiController(IAereiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/aerei")]
        public ActionResult GetAerei()
        {
            return Ok(_repository.GetAerei());
        }

        [HttpGet("api/aerei/{idAereo}")]
        public ActionResult GetAereo(long idAereo)
        {
            return Ok(_repository.GetAereo(idAereo));
        }

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
                return RedirectToAction(nameof(GetAerei));
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
                return RedirectToAction(nameof(GetAerei));
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
                return RedirectToAction(nameof(GetAerei));
            }
            catch
            {
                return View();
            }
        }
    }
}
