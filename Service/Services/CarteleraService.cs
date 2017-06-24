using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CarteleraService
    {
        private AlCineEntities db = new AlCineEntities();

        public List<Cartelera> ListarCalificaciones()
        {
            var Cartelera = db.Carteleras;

            return Cartelera.ToList();
        }

        public Cartelera ObtenerDetalle(int? id)
        {
            Cartelera pelicula = db.Carteleras.Find(id);

            return pelicula;
        }

        public Cartelera EditarCalificacion(int? id)
        {
            Cartelera pelicula = db.Carteleras.Find(id);

            return pelicula;
        }

        public Cartelera BorrarCalificacion(int? id)
        {
            Cartelera pelicula = db.Carteleras.Find(id);

            return pelicula;
        }
    }
}
