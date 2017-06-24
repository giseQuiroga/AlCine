using DataAccessLayer;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Administrator
{
    public class CarteleraAdmin
    {
        protected ICarteleraService iCarteleraService;

        public CarteleraAdmin(ICarteleraService _iCarteleraService)
        {
            this.iCarteleraService = _iCarteleraService;
        }

        public List<Cartelera> ListarCalificaciones()
        {
            var result = this.iCarteleraService.ListarCartelera();

            return result;
        }

        public Cartelera ObtenerDetalle(int? id)
        {
            var result = this.iCarteleraService.ObtenerDetalle(id);

            return result;
        }

        public Cartelera EditarCalificacion(int? id)
        {
            var result = this.iCarteleraService.EditarCartelera(id);

            return result;
        }

        public Cartelera BorrarCalificacion(int? id)
        {
            var result = this.iCarteleraService.BorrarCartelera(id);

            return result;
        }
    }
}
