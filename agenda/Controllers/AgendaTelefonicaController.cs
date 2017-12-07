using Dominio.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace agenda.Controllers
{
  public class AgendaTelefonicaController : Controller
  {
    // GET: AgendaTelefonica
    public ActionResult Index()
    {
      return View();
    }

    public JsonResult GetValues(string sidx, string sord, int page, int rows)  //Gets the todo Lists.
    {
      var _listadoAgenda = new Agenda().ConsultarAgenda();
      int pageIndex = Convert.ToInt32(page) - 1;
      int pageSize = rows;
      var Results = _listadoAgenda.Select(
              a => new
              {
                a.Id,
                a.FirstName,
                a.LastName,
                a.Email,
                a.Extension,
                a.Estado
              });
      int totalRecords = Results.Count();
      var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
      if (sord.ToUpper() == "DESC")
      {
        Results = Results.OrderByDescending(s => s.Id);
        Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
      }
      else
      {
        Results = Results.OrderBy(s => s.Id);
        Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
      }
      var jsonData = new
      {
        total = totalPages,
        page,
        records = totalRecords,
        rows = Results
      };
      return Json(jsonData, JsonRequestBehavior.AllowGet);
    }

    // TODO:insert a new row to the grid logic here
    [HttpPost]
    public string Create([Bind(Exclude = "Id")] Agenda obj)
    {
      string msg;
      try
      {
        if (ModelState.IsValid)
        {
          obj.Guardar();
          msg = "Saved Successfully";
        }
        else
        {
          msg = "Validation data not successfull";
        }
      }
      catch (Exception ex)
      {
        msg = "Error occured:" + ex.Message;
      }
      return msg;
    }
    public string Edit(Agenda obj)
    {
      string msg;
      try
      {
        if (ModelState.IsValid)
        {
          obj.Guardar();
          msg = "Saved Successfully";
        }
        else
        {
          msg = "Validation data not successfull";
        }
      }
      catch (Exception ex)
      {
        msg = "Error occured:" + ex.Message;
      }
      return msg;
    }
    public string Delete(int Id)
    {
      var objFind = new Agenda().ConsultarAgendaPersona(Id);
      objFind.Estado = false;
      objFind.Guardar();
      return "Deleted successfully";
    }
  }
}