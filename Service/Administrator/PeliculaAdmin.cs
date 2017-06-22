using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using DataAccessLayer;


namespace Service.Administrator
{
    public class PeliculaAdmin 
    {
        protected IPeliculaService iPeliculaService;

        public PeliculaAdmin(IPeliculaService _iPeliculaService)
        {
            this.iPeliculaService = _iPeliculaService;
        }

        public List<Pelicula> ListarPeliculas()
        {
            var result = this.iPeliculaService.ListarPeliculas();

            return result;
        }

        public Pelicula ObtenerDetalle(int? id)
        {
            var result = this.iPeliculaService.ObtenerDetalle(id);

            return result;
        }

        public Pelicula EditarPelicula(int? id)
        {
            var result = this.iPeliculaService.ObtenerDetalle(id);

            return result;
        }

        public Pelicula BorrarPelicula(int? id)
        {
            var result = this.iPeliculaService.BorrarPelicula(id);

            return result;
        }
    }
}
