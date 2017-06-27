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
using System.IO;
using ProyectoAlCine.Utilities;

namespace ProyectoAlCine.Controllers
{
    public class PeliculaController : Controller
    {
        private AlCineEntities db = new AlCineEntities();      

        PeliculaAdmin peliculaAdmin = new PeliculaAdmin( new PeliculaService());
     
        public ActionResult Index()
        {
            var peliculas = peliculaAdmin.ListarPeliculas();

            return View(peliculas);
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detalle = peliculaAdmin.ObtenerDetalle(id);

            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            
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
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (ModelState.IsValid)
            {
                var nombreArchivo = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + Path.GetFileName(pelicula.Imagen);
                var path = ImagenesUtility.Guardar(Request.Files[0], nombreArchivo);
                pelicula.Imagen = path;
                pelicula.FechaCarga = DateTime.Now;
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
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editar = peliculaAdmin.EditarPelicula(id);

            if (editar == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdCalificacion = new SelectList(db.Calificaciones, "IdCalificacion", "Nombre", editar.IdCalificacion);

            ViewBag.IdGenero = new SelectList(db.Generos, "IdGenero", "Nombre", editar.IdGenero);
            return View(editar);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPelicula,Nombre,Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga")] Pelicula pelicula)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (ModelState.IsValid)
            {
                var nombreArchivo = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + Path.GetFileName(pelicula.Imagen);
                var path = ImagenesUtility.Guardar(Request.Files[0], nombreArchivo);
                pelicula.Imagen = path;
                pelicula.FechaCarga = DateTime.Now;
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
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var borrar = peliculaAdmin.BorrarPelicula(id);

            if (borrar == null)
            {
                return HttpNotFound();
            }
            return View(borrar);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            var borrar = peliculaAdmin.BorrarPelicula(id);

            db.Peliculas.Remove(borrar);

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
