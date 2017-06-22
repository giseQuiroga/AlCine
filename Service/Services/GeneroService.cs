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
    public class GeneroService : IGeneroService
    {
        private AlCineEntities db = new AlCineEntities();
     
        public List<Genero> ListarGeneros()
        {
            var generos = db.Generos;

            return generos.ToList();
        }

        public Genero ObtenerDetalle(int? id)
        {
            Genero pelicula = db.Generos.Find(id);

            return pelicula;
        }

        public Genero EditarGenero(int? id)
        {
            Genero pelicula = db.Generos.Find(id);

            return pelicula;
        }

        public Genero BorrarGenero(int? id)
        {
            Genero pelicula = db.Generos.Find(id);

            return pelicula;
        }
    }
}
