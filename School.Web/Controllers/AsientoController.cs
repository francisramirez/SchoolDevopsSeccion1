using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities;
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
            var asiento = this.asientoRepository.ObtenerPorId(id);
            return View(asiento);
        }

        // GET: AsientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asiento asiento)
        {
            try
            {
                this.asientoRepository.Agregar(asiento);
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
            {
                var asiento = this.asientoRepository.ObtenerPorId(id);
                return View(asiento);
            }

           


        }

        // POST: AsientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asiento asiento)
        {
            try
            {
                this.asientoRepository.Actualizar(asiento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
