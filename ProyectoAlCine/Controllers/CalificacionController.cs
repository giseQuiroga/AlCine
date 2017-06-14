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
    public class CalificacionController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: Calificacion
        public ActionResult Index()
        {
            return View(db.Calificaciones.ToList());
        }

        // GET: Calificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacione calificacione = db.Calificaciones.Find(id);
            if (calificacione == null)
            {
                return HttpNotFound();
            }
            return View(calificacione);
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
            Calificacione calificacione = db.Calificaciones.Find(id);
            if (calificacione == null)
            {
                return HttpNotFound();
            }
            return View(calificacione);
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
            Calificacione calificacione = db.Calificaciones.Find(id);
            if (calificacione == null)
            {
                return HttpNotFound();
            }
            return View(calificacione);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacione calificacione = db.Calificaciones.Find(id);
            db.Calificaciones.Remove(calificacione);
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
