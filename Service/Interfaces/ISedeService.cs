using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Service.Interfaces
{
    public interface ISedeService
    {
        List<Sede> ListarSede();

        Sede ObtenerDetalle(int? id);

        Sede EditarSede(int? id);

        Sede BorrarSede(int? id);

    }
}
