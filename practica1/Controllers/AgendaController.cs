
using Dominio.Models;
using System;
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
             new Cliente { ClienteId = "1", Nombre = "Julio Avellaneda", Correo = "julito_gtu@hotmail.com"},
             new Cliente { ClienteId = "2", Nombre = "Juan Torres", Correo = "jtorres@hotmail.com"},
             new Cliente { ClienteId = "3", Nombre = "Oscar Camacho", Correo = "oscarca@hotmail.com"},
             new Cliente { ClienteId = "4", Nombre = "Gina Urrego", Correo = "ginna@hotmail.com"},
             new Cliente { ClienteId = "5", Nombre = "Nathalia Ramirez", Correo = "natha@hotmail.com"},
             new Cliente { ClienteId = "6", Nombre = "Raul Rodriguez", Correo = "rodriguez.raul@hotmail.com"},
             new Cliente { ClienteId = "7", Nombre = "Johana Espitia", Correo = "johana_espitia@hotmail.com"},
             new Cliente { ClienteId = "8", Nombre = "Elvis Alfredo Mora Barros", Correo = "elvis.mora@confianza.com.ec"}
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

        public ActionResult Customers()
        {
            return View(clientes);
        }

        public ActionResult GetDataCustomers(JQueryDataTableParams param)
        {
            //    //Traer registros
            IQueryable<Cliente> memberCol = clientes.AsQueryable();

            //    //Manejador de filtros
            int totalCount = memberCol.Count();
            IEnumerable<Cliente> filteredMembers = memberCol;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredMembers = memberCol.Where(m => m.ClienteId.Contains(param.sSearch) || m.Correo.Contains(param.sSearch) || m.Nombre.Contains(param.sSearch));
            }
            //    //Manejador de orden
            var sortIdx = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Cliente, string> orderingFunction =
                                (
                                m => sortIdx == 0 ? m.Nombre : sortIdx == 1 ? m.Correo : m.ClienteId.ToString());
            var sortDirection = Request["sSortDir_0"]; // asc or desc  
            if (sortDirection == "asc")
                filteredMembers = filteredMembers.OrderBy(orderingFunction);
            else
                filteredMembers = filteredMembers.OrderByDescending(orderingFunction);
            var displayedMembers = filteredMembers
                     .Skip(param.iDisplayStart)
                     .Take(param.iDisplayLength);

            //    //Manejardo de resultados
            var result = from a in displayedMembers
                         select new
                         {
                             a.ClienteId,
                             a.Nombre,
                             a.Correo
                         };
            //    //Se devuelven los resultados por json
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = totalCount,
                iTotalDisplayRecords = filteredMembers.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}