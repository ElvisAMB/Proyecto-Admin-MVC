using Dominio.Models;
using System.Web.Mvc;

namespace practica1.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Index()
        {
            return View(new Agenda().ConsultarAgenda());
        }

        public ActionResult Edit(int id)
        {
            return View(new Agenda().ConsultarAgendaPersona(id));
        }

        public ActionResult Crear()
        {
            return View(new Agenda());
        }

        public ActionResult Eliminar(int id)
        {
            return View("Index");
        }
        public ActionResult Detalle(int id)
        {
            return View(new Agenda().ConsultarAgendaPersona(id));
        }

        [HttpPost]
        public ActionResult Guardar(Agenda persona)
        {
            var puedeContinuar = true;
            if (persona != null)
            {
                if (persona.Id == 0)
                {
                    puedeContinuar = false;
                }

                if (persona.FirstName == string.Empty || persona.FirstName == null)
                {
                    puedeContinuar = false;
                }

                if (persona.LastName == string.Empty || persona.LastName == null)
                {
                    puedeContinuar = false;
                }

                if (persona.Email == string.Empty || persona.Email == null)
                {
                    puedeContinuar = false;
                }
            }

            if (!puedeContinuar)
            {
                return RedirectToAction("Editar", persona.Id);
            }

            persona.Guardar();
            return RedirectToAction("Index");
        }
    }
}