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

namespace ProyectoAlCine.Controllers
{
    public class PeliculaController : Controller
    {
        private AlCineEntities db = new AlCineEntities();
        private IPeliculaService _iPeliculaService;

     
       public PeliculaController(IPeliculaService iPeliculaService)
        {
            this._iPeliculaService = iPeliculaService;
        }
        // GET: Pelicula
        public ActionResult Index()
        {
            var peliculas = this._iPeliculaService.ListarPeliculas();
            return View(peliculas);

        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            ViewBag.IdCalificacion = new SelectList(db.Calificaciones, "IdCalificacion", "Nombre");
            ViewBag.IdGenero = new SelectList(db.Generos, "IdGenero", "Nombre");
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPelicula,Nombre,Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCalificacion = new SelectList(db.Calificaciones, "IdCalificacion", "Nombre", pelicula.IdCalificacion);
            ViewBag.IdGenero = new SelectList(db.Generos, "IdGenero", "Nombre", pelicula.IdGenero);
            return View(pelicula);
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCalificacion = new SelectList(db.Calificaciones, "IdCalificacion", "Nombre", pelicula.IdCalificacion);
            ViewBag.IdGenero = new SelectList(db.Generos, "IdGenero", "Nombre", pelicula.IdGenero);
            return View(pelicula);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPelicula,Nombre,Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCalificacion = new SelectList(db.Calificaciones, "IdCalificacion", "Nombre", pelicula.IdCalificacion);
            ViewBag.IdGenero = new SelectList(db.Generos, "IdGenero", "Nombre", pelicula.IdGenero);
            return View(pelicula);
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
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
