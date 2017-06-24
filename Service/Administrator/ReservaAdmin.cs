using System.Collections.Generic;
using Service.Interfaces;
using DataAccessLayer;


namespace Service.Administrator
{
    public class ReservaAdmin
    {

        protected IReservaService iReservaService;

        public ReservaAdmin(IReservaService _iReservaService)
        {
            this.iReservaService = _iReservaService;
        }

        public List<Reserva> ListarReserva()
        {
            var result = this.iReservaService.ListarReserva();

            return result;
        }

        public Reserva ObtenerDetalle(int? id)
        {
            var result = this.iReservaService.ObtenerDetalle(id);

            return result;
        }

        public Reserva EditarCalificacion(int? id)
        {
            var result = this.iReservaService.EditarReserva(id);

            return result;
        }

        public Reserva BorrarCalificacion(int? id)
        {
            var result = this.iReservaService.BorrarReserva(id);

            return result;
        }
    }
}
