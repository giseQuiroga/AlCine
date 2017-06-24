using System.Collections.Generic;
using Service.Interfaces;
using DataAccessLayer;


namespace Service.Administrator
{
    public class SedeAdmin
    {

        protected ISedeService iSedeService;

        public SedeAdmin(ISedeService _iSedeService)
        {
            this.iSedeService = _iSedeService;
        }

        public List<Sede> ListarSede()
        {
            var result = this.iSedeService.ListarSede();

            return result;
        }

        public Sede ObtenerDetalle(int? id)
        {
            var result = this.iSedeService.ObtenerDetalle(id);

            return result;
        }

        public Sede EditarSede(int? id)
        {
            var result = this.iSedeService.EditarSede(id);

            return result;
        }

        public Sede BorrarSede(int? id)
        {
            var result = this.iSedeService.BorrarSede(id);

            return result;
        }
    }
}
