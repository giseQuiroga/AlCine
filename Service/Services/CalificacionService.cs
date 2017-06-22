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

    public class CalificacionService: ICalificacionService
    {       

        private AlCineEntities db = new AlCineEntities();

        public List<Calificacione> ListarCalificaciones()
        {
            var Calificacion = db.Calificaciones;

            return Calificacion.ToList();
        }

        public Calificacione ObtenerDetalle(int? id)
        {
            Calificacione pelicula = db.Calificaciones.Find(id);

            return pelicula;
        }

        public Calificacione EditarCalificacion(int? id)
        {
            Calificacione pelicula = db.Calificaciones.Find(id);

            return pelicula;
        }

        public Calificacione BorrarCalificacion(int? id)
        {
            Calificacione pelicula = db.Calificaciones.Find(id);

            return pelicula;
        }
    }
}
