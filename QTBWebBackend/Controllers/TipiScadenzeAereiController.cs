using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class TipiScadenzeAereiController : Controller
    {
        private ITipiScadenzeAereiRepository _repository;

        public TipiScadenzeAereiController(ITipiScadenzeAereiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/tipiscadenzeaerei")]
        public IActionResult GetTipiScadenzeAerei()
        {
            return Ok(_repository.GetTipiScadenzeAerei());
        }

        [HttpGet("api/tipiscadenzeaerei/{idTipoScadenza}")]
        public IActionResult GetTipiScadenzeAerei(long idTipoScadenza)
        {
            return Ok(_repository.GetTipiScadenzeAerei(idTipoScadenza));
        }

        // GET: TipiScadenzeAereiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipiScadenzeAereiController/Create
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

        // GET: TipiScadenzeAereiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipiScadenzeAereiController/Edit/5
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

        // GET: TipiScadenzeAereiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipiScadenzeAereiController/Delete/5
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
