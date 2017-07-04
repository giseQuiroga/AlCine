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
            if (Convert.ToDateTime(cartelera.FechaInicio).CompareTo(Convert.ToDateTime(cartelera.FechaFin)) >= 0)
            {
                return "Las fechas ingresadas no son válidas.";
            }

            List<Cartelera> carteleras = db.Carteleras.ToList();
            foreach (var c in carteleras)
            {
                if (cartelera.IdSede == c.IdSede)
                {
                    if (cartelera.IdPelicula == c.IdPelicula && cartelera.IdVersion == c.IdVersion)
                    {
                        return "La Película ingresada ya existe en la misma Sede y con la misma Versión";
                    }

                    if (cartelera.FechaInicio >= c.FechaInicio && cartelera.FechaInicio <= c.FechaFin)
                    {
                        if (cartelera.HoraInicio - c.HoraInicio < 30)
                        {
                            return "Cada película debe tener 30 minutos de diferencia.";
                        }
                    }

                        if (cartelera.NumeroSala == c.NumeroSala)
                        {
                        if (cartelera.FechaInicio >= c.FechaInicio && cartelera.FechaInicio <= c.FechaFin)
                        {
                            if (cartelera.Lunes == true && c.Lunes == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                            if (cartelera.Martes == true && c.Martes == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                            if (cartelera.Miercoles == true && c.Miercoles == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                            if (cartelera.Jueves == true && c.Jueves == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                            if (cartelera.Viernes == true && c.Viernes == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                            if (cartelera.Sabado == true && c.Sabado == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                            if (cartelera.Domingo == true && c.Domingo == true)
                            {
                                return "Los días seleccionados ya están ocupados en esta fecha";
                            }
                        }
                    }
                }
            }

            if (db.Carteleras.Where(a=> a.NumeroSala == cartelera.NumeroSala && a.Sede == cartelera.Sede).Count() > 7)
            {
                return "No puede cargar más de 7 funciones por Sala.";
            }

            
            
            return null;

        }

    }
}