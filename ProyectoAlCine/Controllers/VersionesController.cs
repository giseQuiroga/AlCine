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
    public class VersionesController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: Versiones
        public ActionResult Index()
        {
            return View(db.Versiones.ToList());
        }

        // GET: Versiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versione versione = db.Versiones.Find(id);
            if (versione == null)
            {
                return HttpNotFound();
            }
            return View(versione);
        }

        // GET: Versiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Versiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVersion,Nombre")] Versione versione)
        {
            if (ModelState.IsValid)
            {
                db.Versiones.Add(versione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(versione);
        }

        // GET: Versiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versione versione = db.Versiones.Find(id);
            if (versione == null)
            {
                return HttpNotFound();
            }
            return View(versione);
        }

        // POST: Versiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVersion,Nombre")] Versione versione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(versione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(versione);
        }

        // GET: Versiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versione versione = db.Versiones.Find(id);
            if (versione == null)
            {
                return HttpNotFound();
            }
            return View(versione);
        }

        // POST: Versiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Versione versione = db.Versiones.Find(id);
            db.Versiones.Remove(versione);
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
