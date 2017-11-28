using Dominio.Models;
using practica1.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace practica1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel usuario)
        {
            usuario.HoraInicio = DateTime.Now;
            usuario.HoraFin = DateTime.Now;

            Respuesta respuesta = usuario.Verificar(usuario);
            usuario.HoraFin = DateTime.Now;
            if (respuesta.Codigo == 0 && respuesta.Mensaje == "OK")
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}