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
    public class SedeController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: Sede
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            return View(db.Sedes.ToList());
        }

       
        // GET: Sede/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            return View();
        }

        // POST: Sede/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSede,Nombre,Direccion,PrecioGeneral")] Sede sede)
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            if (ModelState.IsValid)
            {
                db.Sedes.Add(sede);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sede);
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sedes.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sede/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSede,Nombre,Direccion,PrecioGeneral")] Sede sede)
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            if (ModelState.IsValid)
            {
                db.Entry(sede).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sede);
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
