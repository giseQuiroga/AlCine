using Service.Administrator;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAlCine.Controllers
{
    public class HomeController : Controller
    {
        PeliculaAdmin peliculaAdmin = new PeliculaAdmin(new PeliculaService());
        public ActionResult Index()
        {
            var peliculas = peliculaAdmin.ListarPeliculas();
            return View(peliculas);
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
    }
}