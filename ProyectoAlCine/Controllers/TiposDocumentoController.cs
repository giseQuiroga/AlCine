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
    public class TiposDocumentoController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: TiposDocumento
        public ActionResult Index()
        {
            return View(db.TiposDocumentos.ToList());
        }

        // GET: TiposDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDocumento tiposDocumento = db.TiposDocumentos.Find(id);
            if (tiposDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tiposDocumento);
        }

        // GET: TiposDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoDocumento,Descripcion")] TiposDocumento tiposDocumento)
        {
            if (ModelState.IsValid)
            {
                db.TiposDocumentos.Add(tiposDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposDocumento);
        }

        // GET: TiposDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDocumento tiposDocumento = db.TiposDocumentos.Find(id);
            if (tiposDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tiposDocumento);
        }

        // POST: TiposDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoDocumento,Descripcion")] TiposDocumento tiposDocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposDocumento);
        }

        // GET: TiposDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDocumento tiposDocumento = db.TiposDocumentos.Find(id);
            if (tiposDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tiposDocumento);
        }

        // POST: TiposDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposDocumento tiposDocumento = db.TiposDocumentos.Find(id);
            db.TiposDocumentos.Remove(tiposDocumento);
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
