using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class TipiVoliController : Controller
    {
        private ITipiVoliRepository _repository;

        public TipiVoliController(ITipiVoliRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/tipivoli")]
        public IActionResult GetTipiVoli()
        {
            return Ok(_repository.GetTipiVoli());
        }

        [HttpGet("api/tipivoli/{idTipoVolo}")]
        public IActionResult GetTipiVoli(long idTipoVolo)
        {
            return Ok(_repository.GetTipiVoli(idTipoVolo));
        }

        // GET: TipiVoliController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipiVoliController/Create
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

        // GET: TipiVoliController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipiVoliController/Edit/5
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

        // GET: TipiVoliController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipiVoliController/Delete/5
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
