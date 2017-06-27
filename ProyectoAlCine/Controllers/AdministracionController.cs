using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfaces;
using Service.Services;
using Service.Administrator;


namespace ProyectoCine.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Inicio()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult Peliculas()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult Cartelera()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult Sedes()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult Reportes()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
    }
}