using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using System;

namespace QTBWebBackend.Controllers
{
    public class TipiManutenzioniController : Controller
    {
        private ITipiManutenzioniRepository _repository;

        public TipiManutenzioniController(ITipiManutenzioniRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/tipimanutenzioni")]
        public IActionResult GetTipiManutenzioni()
        {
            return Ok(_repository.GetTipiManutenzioni());
        }

        [HttpGet("api/tipimanutenzioni/{idTipoManutenzione}")]
        public IActionResult GetTipiManutenzioni(long idTipoManutenzione)
        {
            return Ok(_repository.GetTipiManutenzioni(idTipoManutenzione));
        }

        // GET: TipiManutenzioniController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipiManutenzioniController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipiManutenzioniController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipiManutenzioniController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipiManutenzioniController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipiManutenzioniController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
