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
    public class GeneroController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        GeneroAdmin GeneroAdmin = new GeneroAdmin( new GeneroService());

        // GET: Genero
        public ActionResult Index()
        {
            var generos = GeneroAdmin.ListarGeneros();

            return View(generos);
        }

        // GET: Genero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detalle = GeneroAdmin.ObtenerDetalle(id);

            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGenero,Nombre")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Generos.Add(genero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        // GET: Genero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editar = GeneroAdmin.EditarGenero(id);

            if (editar == null)
            {
                return HttpNotFound();
            }
            return View(editar);
        }

        // POST: Genero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGenero,Nombre")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        // GET: Genero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var borrar = GeneroAdmin.BorrarGenero(id);

            if (borrar == null)
            {
                return HttpNotFound();
            }
            return View(borrar);
        }

        // POST: Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var borrar = GeneroAdmin.BorrarGenero(id);

            db.Generos.Remove(borrar);
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
