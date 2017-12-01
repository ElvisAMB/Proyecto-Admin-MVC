using Dominio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace practica1.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        //public ActionResult Index()
        //{
        //    return View(new Agenda().ConsultarAgenda());
        //}

        public ActionResult Index(string nombre)
        {
            if (nombre == null)
            {
                return View(new Agenda().ConsultarAgenda());
            }
            else
            {
                ViewBag.Name = nombre;
                return View(new Agenda().ConsultarAgenda(nombre));
            }
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
            return View("Index", null);
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

        #region
        ///Para probar un filtro de información
        ///

        private static readonly List<Cliente> clientes = new List<Cliente>()
        {
             new Cliente { ClienteId = 1, Nombre = "Julio Avellaneda", Correo = "julito_gtu@hotmail.com"},
             new Cliente { ClienteId = 2, Nombre = "Juan Torres", Correo = "jtorres@hotmail.com"},
             new Cliente { ClienteId = 3, Nombre = "Oscar Camacho", Correo = "oscarca@hotmail.com"},
             new Cliente { ClienteId = 4, Nombre = "Gina Urrego", Correo = "ginna@hotmail.com"},
             new Cliente { ClienteId = 5, Nombre = "Nathalia Ramirez", Correo = "natha@hotmail.com"},
             new Cliente { ClienteId = 6, Nombre = "Raul Rodriguez", Correo = "rodriguez.raul@hotmail.com"},
             new Cliente { ClienteId = 7, Nombre = "Johana Espitia", Correo = "johana_espitia@hotmail.com"},
             new Cliente { ClienteId = 8, Nombre = "Elvis Alfredo Mora Barros", Correo = "elvis.mora@confianza.com.ec"}
        };

        public ActionResult ConsultaClientes(string name)
        {
            if (string.IsNullOrEmpty(name))
                return View(clientes);
            else
            {
                ViewBag.Name = name;
                return View(clientes.Where(c => c.Nombre.ToLower().Contains(name)));
            }
        }
        #endregion
    }
}