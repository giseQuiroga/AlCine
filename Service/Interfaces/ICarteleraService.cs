using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICarteleraService
    {
        List<Cartelera> ListarCartelera();

        Cartelera ObtenerDetalle(int? id);

        Cartelera EditarCartelera(int? id);

        Cartelera BorrarCartelera(int? id);
    }
}
