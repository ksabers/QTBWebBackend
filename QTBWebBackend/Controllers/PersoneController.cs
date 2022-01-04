using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Interfaces;

namespace QTBWebBackend.Controllers
{
    public class PersoneController : Controller
    {
        private IPersoneRepository _repository;

        public PersoneController(IPersoneRepository repository)
        {
            _repository = repository;
        }

        //[Authorize]
        [HttpGet("api/persone")]
        public IActionResult GetPersone()
        {
            return Ok(_repository.GetPersone());
        }

        [Authorize]
        [HttpGet("api/persone/{idPersona}")]
        public IActionResult GetPersone(long idPersona)
        {
            return Ok(_repository.GetPersone(idPersona));
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
                return RedirectToAction(nameof(GetPersone));
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
                return RedirectToAction(nameof(GetPersone));
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
                return RedirectToAction(nameof(GetPersone));
            }
            catch
            {
                return View();
            }
        }
    }
}