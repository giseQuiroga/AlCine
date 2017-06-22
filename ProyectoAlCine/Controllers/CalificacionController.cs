using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Service.Interfaces;
using Service.Services;
using Service.Administrator;


namespace ProyectoAlCine.Controllers
{
    public class CalificacionController : Controller
    {
        private AlCineEntities db = new AlCineEntities();       

        CalificacionAdmin calificacionAdmin = new CalificacionAdmin(new CalificacionService());

        // GET: Calificacion
        public ActionResult Index()
        {
            var calificaciones = calificacionAdmin.ListarCalificaciones();

            return View(calificaciones);
        }

        // GET: Calificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detalle = calificacionAdmin.ObtenerDetalle(id);

            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Calificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calificacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCalificacion,Nombre")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                db.Calificaciones.Add(calificacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calificacione);
        }

        // GET: Calificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editar = calificacionAdmin.EditarCalificacion(id);

            if (editar == null)
            {
                return HttpNotFound();
            }
            return View(editar);
        }

        // POST: Calificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCalificacion,Nombre")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calificacione);
        }

        // GET: Calificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var borrar = calificacionAdmin.BorrarCalificacion(id);

            if (borrar == null)
            {
                return HttpNotFound();
            }
            return View(borrar);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var borrar = calificacionAdmin.BorrarCalificacion(id);

            db.Calificaciones.Remove(borrar);
            db.SaveChanges();
            return RedirectToAction("Index");
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
