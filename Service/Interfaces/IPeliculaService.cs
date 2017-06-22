using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Service.Interfaces
{
    public interface IPeliculaService
    {
        List<Pelicula> ListarPeliculas();

        Pelicula ObtenerDetalle(int? id);

        Pelicula EditarPelicula(int? id);

        Pelicula BorrarPelicula(int? id);

    }
}
