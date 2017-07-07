using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using ProyectoAlCine.Utilities;

using System.Text;
using System.Text.RegularExpressions;

namespace ProyectoAlCine.Controllers
{
    public class ReservaController : Controller
    {
        private AlCineEntities DB = new AlCineEntities();
        private List<string> HorariosConvertidos = new List<string>();
        private List<string> DiasProyeccionPelicula = new List<string>();
        private List<DiasSemana> ListaDias = new List<DiasSemana>();
        private List<Fecha> ListaFechas = new List<Fecha>();


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

        public ActionResult ListarReservas(int pelicula, DateTime fechaInicio, DateTime fechaFin)
        {

            var reservas = DB.Reservas.Where(r => r.IdPelicula == pelicula && r.FechaCarga >= fechaInicio && r.FechaCarga <= fechaFin).Include(r => r.Pelicula).Include(r => r.Sede).Include(r => r.TiposDocumento).Include(r => r.Versione).ToList();

            var result = reservas.Select(x => new { Pelicula = x.Pelicula.Nombre, Precio = x.Sede.PrecioGeneral, Sede = x.Sede.Nombre, Version = x.Versione.Nombre }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        // GET: Reserva/Details/5
        public ActionResult Details(int? id)
        {

            var reservas = DB.Reservas.OrderByDescending(r => r.IdReserva).Include(r => r.Pelicula).Include(r => r.Sede).Include(r => r.TiposDocumento).Include(r => r.Versione).FirstOrDefault();
            ViewBag.Mensaje = "La reserva estará vigente hasta 1hr antes de la función elegida y deberá ser confirmada en el cine seleccionado.";
            ViewBag.DatosReserva = "Código de Reserva: " + reservas.IdReserva + " - Precio Total: " + reservas.Sede.PrecioGeneral * reservas.CantidadEntradas;

            return View(reservas);
        }

        // GET: Reserva/Create
        public ActionResult Create(int idPelicula)
        {

            var idSede = DB.Carteleras.Where(x => x.IdPelicula == idPelicula).Select(y => y.IdSede).ToList();

            ViewBag.IdSede = new SelectList(DB.Sedes.Where(x => idSede.Contains(x.IdSede)), "IdSede", "Nombre").ToList();

            ViewBag.IdVersion = new SelectList("", "IdVersion", "Nombre");

            ViewBag.IdPelicula = DB.Peliculas.Where(x => x.IdPelicula == idPelicula).Select(y => y.IdPelicula).FirstOrDefault();

            ViewBag.IdTipoDocumento = new SelectList(DB.TiposDocumentos, "IdTipoDocumento", "Descripcion");

            ViewBag.IdHoraInicio = new SelectList(HorariosConvertidos);

            ViewBag.fechaActual = DateTime.Today.ToShortDateString();

            ViewBag.IdDias = new SelectList("", "Dia", "Dia");

            ViewBag.PeliculaNombre = DB.Peliculas.Where(x => x.IdPelicula == idPelicula).Select(y => y.Nombre).FirstOrDefault();

            return View();
        }


        // POST: Reserva/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,IdSede,IdVersion,IdPelicula,FechaHoraInicio,Email,IdTipoDocumento,NumeroDocumento,CantidadEntradas,FechaCarga")] Reserva reserva)
        {
            try
            {
                reserva.FechaHoraInicio = Convert.ToDateTime(Request.Form["IdDias"] + " " + Request.Form["IdHoraInicio"]);

                var pelicula = DB.Peliculas.Where(x => x.IdPelicula == reserva.IdPelicula).FirstOrDefault();
                var sedes = DB.Sedes.Where(x => x.IdSede == reserva.IdSede).FirstOrDefault();
                var tiposDocumentos = DB.TiposDocumentos.Where(x => x.IdTipoDocumento == reserva.IdTipoDocumento).FirstOrDefault();
                var versiones = DB.Versiones.Where(x => x.IdVersion == reserva.IdVersion).FirstOrDefault();

                reserva.Pelicula = pelicula;
                reserva.Sede = sedes;
                reserva.TiposDocumento = tiposDocumentos;
                reserva.Versione = versiones;

                if (ModelState.IsValid)
                {
                    DB.Reservas.Add(reserva);
                    DB.SaveChanges();
                    return RedirectToAction("Details");
                }

                ViewBag.IdPelicula = new SelectList(DB.Peliculas, "IdPelicula", "Nombre", reserva.IdPelicula);
                ViewBag.IdSede = new SelectList(DB.Sedes, "IdSede", "Nombre", reserva.IdSede);
                ViewBag.IdTipoDocumento = new SelectList(DB.TiposDocumentos, "IdTipoDocumento", "Descripcion", reserva.IdTipoDocumento);
                ViewBag.IdVersion = new SelectList(DB.Versiones, "IdVersion", "Nombre", reserva.IdVersion);
                ViewBag.IdHoraInicio = new SelectList(HorariosConvertidos);
            }
            catch (Exception e)
            {
                return View("Create",e.Message);
                throw;
            }
            

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

            Reserva reserva = DB.Reservas.Find(id);
            DB.Reservas.Remove(reserva);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ChangeSede(int idSede, int idPelicula)
        {
            var idVersion = DB.Carteleras.Where(x => x.Sede.IdSede == idSede && x.IdPelicula == idPelicula).Select(y => y.IdVersion).ToList();
            var versiones = new SelectList(DB.Versiones.Where(y => idVersion.Contains(y.IdVersion)), "IdVersion", "Nombre");
            return Json(versiones, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeVersion(int idSede, int idVersion, int idPelicula)
        {

            DiasProyeccionPelicula = Helper.ObtenerDias(idSede, idVersion, idPelicula);
            ListaFechas = Helper.ObtenerFechas();

            return Json(ListaFechas, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ChangeDia(int idSede, int idVersion, int idPelicula)
        {
            HorariosConvertidos = Helper.ConstruirHora(idSede, idVersion, idPelicula);
            return Json(HorariosConvertidos, JsonRequestBehavior.AllowGet);
        }

    }
}
