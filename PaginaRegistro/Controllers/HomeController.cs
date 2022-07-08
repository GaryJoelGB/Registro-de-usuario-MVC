using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using PaginaRegistro.Permiso;
using PaginaRegistro.Models;

namespace PaginaRegistro.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PermisosRol(Rol.Administrador)]
        public ActionResult About()
        {
            ViewBag.Message = "Bienvenido a la pagina de Gary";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Estos son tus contacto.";

            return View();
        }


        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no tiene permiso para ver esta pagina";

            return View();
        }



        public ActionResult CerrarSeccion()
        {

            FormsAuthentication.SignOut();
            Session["Usuario"] = null;

            return RedirectToAction("Index", "Acceso");
        }
    }
}