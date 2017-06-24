﻿using System;
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
    public class CarteleraController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: Cartelera
        public ActionResult Index()
        {
            var carteleras = db.Carteleras.Include(c => c.Pelicula).Include(c => c.Sede).Include(c => c.Versione);
            return View(carteleras.ToList());
        }

        // GET: Cartelera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartelera cartelera = db.Carteleras.Find(id);
            if (cartelera == null)
            {
                return HttpNotFound();
            }
            return View(cartelera);
        }

        // GET: Cartelera/Create
        public ActionResult Create()
        {
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre");
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre");
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre");
            return View();
        }

        // POST: Cartelera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCartelera,IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga")] Cartelera cartelera)
        {
            if (ModelState.IsValid)
            {
                db.Carteleras.Add(cartelera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", cartelera.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", cartelera.IdSede);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", cartelera.IdVersion);
            return View(cartelera);
        }

        // GET: Cartelera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartelera cartelera = db.Carteleras.Find(id);
            if (cartelera == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", cartelera.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", cartelera.IdSede);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", cartelera.IdVersion);
            return View(cartelera);
        }

        // POST: Cartelera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCartelera,IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga")] Cartelera cartelera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartelera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", cartelera.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", cartelera.IdSede);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", cartelera.IdVersion);
            return View(cartelera);
        }

        // GET: Cartelera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartelera cartelera = db.Carteleras.Find(id);
            if (cartelera == null)
            {
                return HttpNotFound();
            }
            return View(cartelera);
        }

        // POST: Cartelera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cartelera cartelera = db.Carteleras.Find(id);
            db.Carteleras.Remove(cartelera);
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
