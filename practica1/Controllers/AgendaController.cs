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
    }
}