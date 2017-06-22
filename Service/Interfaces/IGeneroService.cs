using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Service.Interfaces
{
    public interface IGeneroService
    {

        List<Genero> ListarGeneros();

        Genero ObtenerDetalle(int? id);
       
        Genero EditarGenero(int? id);

        Genero BorrarGenero(int? id);


    }
}
