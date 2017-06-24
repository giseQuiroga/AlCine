using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Service.Interfaces
{
    public interface IReservaService
    {
        List<Reserva> ListarReserva();

        Reserva ObtenerDetalle(int? id);

        Reserva EditarReserva(int? id);

        Reserva BorrarReserva(int? id);

    }
}
