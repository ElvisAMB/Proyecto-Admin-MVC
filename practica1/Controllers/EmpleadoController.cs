using Dominio.Models;
using System.Linq;
using System.Web.Mvc;

namespace practica1.Controllers
{
    public class EmpleadoController : Controller
    {
    // GET: Empleado
    public ActionResult Index(string filter = null, int page = 1, int pageSize = 10, string sort = "Id", string sortdir = "DESC")
    {

      var _listado = new Agenda().ConsultarAgenda();

      var records = new PagedList<Agenda>();
      ViewBag.filter = filter;

      records.Content = _listado
                    .Where(x => filter == null || (x.CompleteNames.Contains(filter)) || x.Extension.Contains(filter))
                    .OrderBy(x => sort + " " + sortdir)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

      // Count
      records.TotalRecords = _listado.Where(x => filter == null || (x.CompleteNames.Contains(filter)) || x.Extension.Contains(filter)).Count();

      records.CurrentPage = page;
      records.PageSize = pageSize;

      return View(records);
    }

    public ActionResult Details(int id = 0)
    {

      Agenda persona = new Agenda().ConsultarAgendaPersona(id);
      if (persona == null)
      {
        return HttpNotFound();
      }
      return PartialView("Details", persona);
    }

    [HttpGet]
    public ActionResult Create()
    {
      Agenda persona = new Agenda();
      return PartialView("Create", persona);
    }

    [HttpPost]
    public JsonResult Create(Agenda persona)
    {
      if (ModelState.IsValid)
      {
        persona.Guardar();
        return Json(new { success = true });
      }
      return Json(persona.ConsultarAgenda(), JsonRequestBehavior.AllowGet);
    }

    #region Editar
    // GET: /Phone/Edit/5
    [HttpGet]
    public ActionResult Edit(int id = 0)
    {
      var persona = new Agenda().ConsultarAgendaPersona(id);
      if (persona == null)
      {
        return HttpNotFound();
      }

      return PartialView("Edit", persona);
    }


    // POST: /Phone/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Agenda persona)
    {
      if (ModelState.IsValid)
      {
        var personaFind = persona.ConsultarAgendaPersona(persona.Id);

        persona.Guardar();

        return Json(new { success = true });
      }
      return PartialView("Edit", persona.ConsultarAgenda());
    }
    #endregion

    #region Eliminar
    // GET: /Phone/Delete/5
    public ActionResult Delete(int id = 0)
    {
      Agenda persona =   new Agenda().ConsultarAgendaPersona(id);
      if (persona == null)
      {
        return HttpNotFound();
      }
      return PartialView("Delete", persona);
    }

    // POST: /Phone/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Agenda persona = new Agenda().ConsultarAgendaPersona(id);
      persona.Estado = false;
      persona.Guardar();
      return Json(new { success = true });
    }
    #endregion

  }
}