using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Data.Interfaces;

namespace School.Web.Controllers
{
    public class AsientoController : Controller
    {
        private readonly IAsientoRepository asientoRepository;

        public AsientoController(IAsientoRepository asientoRepository)
        {
            this.asientoRepository = asientoRepository;
        }

        // GET: AsientoController
        public ActionResult Index()
        {
            var asientos = this.asientoRepository.TraerTodos();
            return View(asientos);
        }

        // GET: AsientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsientoController/Create
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

        // GET: AsientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsientoController/Edit/5
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

        // GET: AsientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsientoController/Delete/5
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
