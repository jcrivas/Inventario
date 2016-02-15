using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByS.Inventario.Entities;
using ByS.Inventario.Logic;
using ByS.General.CodigoUsuario;
using ByS.General.Entities;
using WebByS.Models;

namespace WebByS.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public string Validar(string usuario, string clave)
        {
            string rpta = "";
            brUsuario obrUsuario = new brUsuario();
            beEmpleado obeEmpleado = obrUsuario.ValidarLogin(usuario, clave);
            if (obeEmpleado != null)
            {
                LoginEntity model = new LoginEntity();
                model.Usuario = obeEmpleado.Login;
                model.Nombre = obeEmpleado.Nombre + " " + obeEmpleado.Apellido;
                Session["Usuario"] = model;
                Session["Empleado"] = obeEmpleado;
                rpta = "Bienvenido " + obeEmpleado.Nombre + " " + obeEmpleado.Apellido;
            }
            else rpta = "Login invalido. Intenta de nuevo";
            return rpta;
        }

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}
