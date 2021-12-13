using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;
using QTBWebBackend.Models;
using QTBWebBackend.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace QTBWebBackend.Controllers
{
    public class VoliController : Controller
    {
        private IVoliRepository _repository;

        public VoliController(IVoliRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/voli")]
        public IActionResult GetVoli()
        {
            return Ok(_repository.GetVoli());
        }

        [HttpGet("api/voli/aerei/{idAereo}")]
        public IActionResult GetVoliDiUnAereo(long idAereo)
        {
            return Ok(_repository.GetVoliDiUnAereo(idAereo));
        }

        [HttpGet("api/voli/{idVolo}")]
        public IActionResult GetVolo(long idVolo)
        {
            return Ok(_repository.GetVolo(idVolo));
        }


        [HttpPost("api/voli")]
        public async Task<IActionResult> PostVolo([FromBody] VoloViewModel volo)
        {
            Voli? voloCreato = await _repository.PostVolo(volo);
            if (voloCreato != null)
            {
                return Created($"api/voli/{voloCreato.Id}", voloCreato);
            }
            else
            {
                return BadRequest("Errore");
            }
        }
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetVoli));
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
                return RedirectToAction(nameof(GetVoli));
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
                return RedirectToAction(nameof(GetVoli));
            }
            catch
            {
                return View();
            }
        }
    }
}