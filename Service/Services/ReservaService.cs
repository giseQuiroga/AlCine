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
    public class ReservaService : IReservaService
    {
        private AlCineEntities db = new AlCineEntities();

        public List<Reserva> ListarReserva()
        {
            var reserva = db.Reservas.Select(r => r);            
            return reserva.ToList() ;
        }

        public Reserva ObtenerDetalle(int? id)
        {
            Reserva reserva = db.Reservas.Find(id);

            return reserva;
        }

        public Reserva EditarReserva(int? id)
        {
            Reserva reserva = db.Reservas.Find(id);

            return reserva;
        }

        public Reserva BorrarReserva(int? id)
        {
            Reserva reserva = db.Reservas.Find(id);

            return reserva;
        }
    }
}
