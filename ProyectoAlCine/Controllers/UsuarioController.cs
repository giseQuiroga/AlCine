using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace ProyectoAlCine.Controllers
{
    public class UsuarioController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

       
        // LOGIN
     
        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Inicio", "Administracion");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {           
                var user = db.Usuarios.Where(model => model.NombreUsuario.Equals(u.NombreUsuario) && model.Password.Equals(u.Password)).FirstOrDefault();

                if (user != null)
                {
                    Session["Admin"] = user.NombreUsuario.ToString();

                    if (TempData["urlAction"] == null)
                    {
                    return RedirectToAction("Index", "Administracion");
                    }

                    return RedirectToAction(TempData["urlAction"].ToString(), TempData["urlController"].ToString());
                }

                else
                {
                    ModelState.AddModelError("incorrecto", "El usuario o la contraseña no son correctos");
                }

            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

//REGISTRO

    [HttpGet]
        public ActionResult Registro()
        {
            if (Session["user"] != null)
            {
                RedirectToAction("Inicio", "Administracion");
            }

            return View();

        }

        [HttpPost]
        public ActionResult Registro(Usuario u)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
