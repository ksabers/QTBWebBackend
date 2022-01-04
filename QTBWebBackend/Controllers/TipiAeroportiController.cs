using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class TipiAeroportiController : Controller
    {
        private ITipiAeroportiRepository _repository;

        public TipiAeroportiController(ITipiAeroportiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/tipiaeroporti")]
        public IActionResult GetTipiAeroporti()
        {
            return Ok(_repository.GetTipiAeroporti());
        }

        [HttpGet("api/tipiaeroporti/{idTipoAeroporto}")]
        public IActionResult GetTipiAeroporti(long idTipoAeroporto)
        {
            return Ok(_repository.GetTipiAeroporti(idTipoAeroporto));
        }

        // GET: TipiAeroportiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipiAeroportiController/Create
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

        // GET: TipiAeroportiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipiAeroportiController/Edit/5
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

        // GET: TipiAeroportiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipiAeroportiController/Delete/5
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
