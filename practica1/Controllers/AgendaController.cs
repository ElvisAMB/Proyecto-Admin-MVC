
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

        public ActionResult ConsultaClientes(string name)
        {
            if (string.IsNullOrEmpty(name))
                return View(new Cliente().ObtenerClientes());
            else
            {
                ViewBag.Name = name;
                return View(new Cliente().ObtenerClientes().Where(c => c.Nombre.ToLower().Contains(name)));
            }
        }
        #endregion

        public ActionResult Customers()
        {
            return View(new Cliente().ObtenerClientes());
        }

        public ActionResult GetDataCustomers(JQueryDataTableParams param)
        {
            //    //Traer registros
            IQueryable<Cliente> memberCol = new Cliente().ObtenerClientes().AsQueryable();

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
                                m => sortIdx == 0 ? m.ClienteId.ToString() : sortIdx == 1 ? m.Nombre : m.Correo);
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