using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAlCine.Models
{
    public class CarteleraNegocio
    {
        private AlCineEntities db = new AlCineEntities();

        public string validarCartelera(Cartelera cartelera)
        {
            DateTime fecha_inicio = Convert.ToDateTime(cartelera.FechaInicio.ToShortDateString());
            DateTime fecha_fin = Convert.ToDateTime(cartelera.FechaFin.ToShortDateString());

            if (db.Carteleras.Where(a=> a.NumeroSala == cartelera.NumeroSala).Count() > 7)
            {
                return "No puede cargar más de 7 funciones por Sala.";
            }

            if (db.Carteleras.Where(b => b.HoraInicio - cartelera.HoraInicio < 30).Count() > 0)
            {
                return "Las funciones no pueden tener menos de 30 minutos de diferencia.";
            }

            if (db.Carteleras.Where(c => c.IdPelicula == cartelera.IdPelicula && c.IdSede == cartelera.IdSede && c.IdVersion == cartelera.IdVersion).Count() > 0)
            {
                return "Ya existe esta función con la misma Versión en la misma Sede.";
            }

            if (db.Carteleras.Where(d => d.FechaInicio >= fecha_inicio && d.FechaFin >= fecha_fin && d.FechaInicio <= fecha_fin).Count() > 0)
            {

                return "Ya existe una cartelera que utiliza la misma Fecha final.";
            }

            if (db.Carteleras.Where(e => e.FechaInicio <= fecha_inicio && e.FechaFin >= fecha_fin).Count() > 0)
            {
                return "Ya existe una cartelera en el período indicado.";
            }

            if (db.Carteleras.Where(f => f.FechaInicio <= fecha_inicio && f.FechaFin <= fecha_fin && f.FechaFin >= fecha_inicio).Count() > 0)
            {
                return "Ya existe una cartelera que utiliza la misma Fecha inicial.";
            }
            
            return null;

        }

    }
}