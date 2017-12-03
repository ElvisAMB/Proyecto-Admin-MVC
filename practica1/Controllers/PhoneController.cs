using Dominio.Models;
using practica1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace practica1.Controllers
{
  public class PhoneController : Controller
  {
    List<Phone> phones = new Phone().Seed();

    // GET: Phone
    public ActionResult Index(string filter = null, int page = 1, int pageSize = 5, string sort = "PhoneId", string sortdir = "DESC")
    {

      var records = new PagedList<Phone>();
      ViewBag.filter = filter;

      records.Content = phones
                    .Where(x => filter == null || (x.Model.Contains(filter)) || x.Company.Contains(filter))
                    .OrderBy(x => sort + " " + sortdir)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

      // Count
      records.TotalRecords = phones.Where(x => filter == null || (x.Model.Contains(filter)) || x.Company.Contains(filter)).Count();

      records.CurrentPage = page;
      records.PageSize = pageSize;

      return View(records);
    }

    public ActionResult Details(int id = 0)
    {
      Phone phone = phones.Find(f => f.PhoneId == id);
      if (phone == null)
      {
        return HttpNotFound();
      }
      return PartialView("Details", phone);
    }

    #region Create
    // GET: /Phone/Create
    [HttpGet]
    public ActionResult Create()
    {
      var phone = new Phone();
      return PartialView("Create", phone);
    }
    // POST: /Phone/Create
    [HttpPost]
    public JsonResult Create(Phone phone)
    {
      if (ModelState.IsValid)
      {
        phones.Add(phone);
        return Json(new { success = true });
      }
      return Json(phone, JsonRequestBehavior.AllowGet);
    }
    #endregion

    #region Editar
    // GET: /Phone/Edit/5
    [HttpGet]
    public ActionResult Edit(int id = 0)
    {
      var phone = phones.Find(f => f.PhoneId == id);
      if (phone == null)
      {
        return HttpNotFound();
      }

      return PartialView("Edit", phone);
    }


    // POST: /Phone/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Phone phone)
    {
      if (ModelState.IsValid)
      {
        var phoneFind = phones.Find(f => f.PhoneId == phone.PhoneId);
        phoneFind.Company = phone.Company;
        phoneFind.Model = phone.Model;
        phoneFind.Price = phone.Price;
        
        return Json(new { success = true });
      }
      return PartialView("Edit", phone);
    }
    #endregion

    #region Eliminar
    // GET: /Phone/Delete/5
    public ActionResult Delete(int id = 0)
    {
      Phone phone = phones.Find(f=>f.PhoneId == id);
      if (phone == null)
      {
        return HttpNotFound();
      }
      return PartialView("Delete", phone);
    }

    // POST: /Phone/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      var phone = phones.Find(x=>x.PhoneId == id);
      phones.Remove(phone);
      return Json(new { success = true });
    }
    #endregion

  }
}