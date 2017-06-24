using System.Collections.Generic;
using Service.Interfaces;
using DataAccessLayer;


namespace Service.Administrator
{
    public class CalificacionAdmin
    {      

        protected ICalificacionService iCalificacionService;

        public CalificacionAdmin(ICalificacionService _iCalificacionService)
        {
            this.iCalificacionService = _iCalificacionService;
        }

        public List<Calificacione> ListarCalificaciones()
        {
            var result = this.iCalificacionService.ListarCalificaciones();

            return result;
        }

        public Calificacione ObtenerDetalle(int? id)
        {
            var result = this.iCalificacionService.ObtenerDetalle(id);

            return result;
        }

        public Calificacione EditarCalificacion(int? id)
        {
            var result = this.iCalificacionService.EditarCalificacion(id);

            return result;
        }

        public Calificacione BorrarCalificacion(int? id)
        {
            var result = this.iCalificacionService.BorrarCalificacion(id);

            return result;
        }
    }
}
