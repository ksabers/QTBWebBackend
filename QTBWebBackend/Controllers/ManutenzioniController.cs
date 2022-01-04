using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;

namespace QTBWebBackend.Controllers
{
    public class ManutenzioniController : Controller
    {
        private IManutenzioniRepository _repository;

        public ManutenzioniController(IManutenzioniRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/manutenzioni")]
        public IActionResult GetManutenzioni()
        {
            return Ok(_repository.GetManutenzioni());
        }

        [HttpGet("api/manutenzioni/{idManutenzione}")]
        public IActionResult GetManutenzioni(long idManutenzione)
        {
            return Ok(_repository.GetManutenzioni(idManutenzione));
        }


        // GET: AeroportiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AeroportiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetManutenzioni));
            }
            catch
            {
                return View();
            }
        }

        // GET: AeroportiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AeroportiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetManutenzioni));
            }
            catch
            {
                return View();
            }
        }

        // GET: AeroportiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AeroportiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetManutenzioni));
            }
            catch
            {
                return View();
            }
        }
    }
}