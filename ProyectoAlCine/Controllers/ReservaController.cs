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
    public class ReservaController : Controller
    {
        private AlCineEntities db = new AlCineEntities();

        // GET: Reserva
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            var reserva = new List<Reserva>();
            return View(reserva);
        }

        public ActionResult ListarReservas (int pelicula, DateTime fechaInicio, DateTime fechaFin)
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            var reservas = db.Reservas.Where(r => r.IdPelicula == pelicula && r.FechaCarga >= fechaInicio && r.FechaCarga <= fechaFin).Include(r => r.Pelicula).Include(r => r.Sede).Include(r => r.TiposDocumento).Include(r => r.Versione).ToList();
            ViewBag.Reporte = reservas;
            return View("Index", reservas);

        }


        // GET: Reserva/Details/5
        public ActionResult Details(int? id)
        {

            var reservas = db.Reservas.OrderByDescending(r => r.IdReserva).Include(r => r.Pelicula).Include(r => r.Sede).Include(r => r.TiposDocumento).Include(r => r.Versione).FirstOrDefault();
            ViewBag.Mensaje = "La reserva estará vigente hasta 1hr antes de la función elegida y deberá ser confirmada en el cine seleccionado.";
            ViewBag.DatosReserva = "Código de Reserva: " + reservas.IdReserva + " - Precio Total: " + reservas.Sede.PrecioGeneral * reservas.CantidadEntradas;

            return View(reservas);
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre");
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre");
            ViewBag.IdTipoDocumento = new SelectList(db.TiposDocumentos, "IdTipoDocumento", "Descripcion");
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,IdSede,IdVersion,IdPelicula,FechaHoraInicio,Email,IdTipoDocumento,NumeroDocumento,CantidadEntradas")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Mensaje = "La reserva estará vigente hasta 1hr antes de la función elegida y deberá ser confirmada en el cine seleccionado.";
                //ViewBag.DatosReserva = "Código de Reserva: " + reserva.IdReserva + " - Precio Total: " + reserva.Sede.PrecioGeneral * reserva.CantidadEntradas;
                reserva.FechaCarga = DateTime.Now;
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", reserva.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", reserva.IdSede);
            ViewBag.IdTipoDocumento = new SelectList(db.TiposDocumentos, "IdTipoDocumento", "Descripcion", reserva.IdTipoDocumento);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", reserva.IdVersion);
            return View(reserva);
        }

       
        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Admin"] == null)
            {
                TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Usuario");
            }

            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
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
