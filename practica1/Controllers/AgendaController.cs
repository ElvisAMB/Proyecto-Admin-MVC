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
            persona.Guardar();
            return View("Index");
        }
    }
}