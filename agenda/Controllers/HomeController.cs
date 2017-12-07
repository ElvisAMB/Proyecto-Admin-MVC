using agenda.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace agenda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View("Index","_MenuPrincipal");
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Archivo()
        {
            return View(new FileModel());
        }

        [HttpPost]
        public ActionResult SubirArchivo(FileModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Use your file here
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        model.File.InputStream.CopyTo(memoryStream);
                        string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.File.FileName).ToLower();
                        model.File.SaveAs(Server.MapPath("~/Uploads/" + archivo));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View("Archivo");
        }
    }
}
