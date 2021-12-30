using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class AeroportiController : Controller
    {
        private IAeroportiRepository _repository;

        public AeroportiController(IAeroportiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/aeroporti")]
        public IActionResult GetAeroporti()
        {
            return Ok(_repository.GetAeroporti());
        }

        [HttpGet("api/aeroporti/{idAeroporto}")]
        public IActionResult GetAeroporto(long idAeroporto)
        {
            return Ok(_repository.GetAeroporto(idAeroporto));
        }

        // GET: AeroportiController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("api/aeroporti")]
        public async Task<IActionResult> PostAeroporto([FromBody] AeroportoViewModel aeroporto)
        {
            Aeroporti? aeroportoCreato = await _repository.PostAeroporto(aeroporto);
            if (aeroportoCreato != null)
            {
                return Created($"api/aeroporti/{aeroportoCreato.Id}", aeroportoCreato);
            }
            else
            {
                return BadRequest("Errore");
            }
        }

        // POST: AeroportiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetAeroporti));
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
                return RedirectToAction(nameof(GetAeroporti));
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
                return RedirectToAction(nameof(GetAeroporti));
            }
            catch
            {
                return View();
            }
        }
    }
}