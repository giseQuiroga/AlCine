using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using DataAccessLayer;
using System.Data.Entity;


namespace Service.Services
{
    public class PeliculaService : IPeliculaService
    {
        private AlCineEntities db = new AlCineEntities();

        public List<Pelicula> ListarPeliculas()
        {
            var fechaActual = DateTime.Today;
            var unMes = DateTime.Today.AddDays(30);
            var peliculas = db.Carteleras.Where(x => DateTime.Today >= x.FechaInicio && DateTime.Today <= x.FechaFin && unMes >= x.FechaInicio).Select(y => y.Pelicula).ToList();
            return peliculas.ToList();
        }

        public Pelicula ObtenerDetalle(int? id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);

            return pelicula;
        }

        public Pelicula EditarPelicula(int? id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);

            return pelicula;
        }

        public Pelicula BorrarPelicula(int? id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);

            return pelicula;
        }
    }
}
