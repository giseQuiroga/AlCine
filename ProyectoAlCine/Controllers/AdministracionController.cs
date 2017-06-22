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
            return View();
        }

        public ActionResult Peliculas()
        {
            return View();
        }

        public ActionResult Cartelera()
        {
            return View();
        }

        public ActionResult Sedes()
        {
            return View();
        }

        public ActionResult Reportes()
        {
            return View();
        }
    }
}