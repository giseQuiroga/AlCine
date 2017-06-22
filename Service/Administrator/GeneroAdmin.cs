using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using DataAccessLayer;


namespace Service.Administrator
{
    public class GeneroAdmin
    {      

        protected IGeneroService IGeneroService;

        public GeneroAdmin(IGeneroService _iGeneroService)
        {
            this.IGeneroService = _iGeneroService;
        }

        public List<Genero> ListarGeneros()
        {
            var result = this.IGeneroService.ListarGeneros();

            return result;
        }

        public Genero ObtenerDetalle(int? id)
        {
            var result = this.IGeneroService.ObtenerDetalle(id);

            return result;
        }

        public Genero EditarGenero(int? id)
        {
            var result = this.IGeneroService.ObtenerDetalle(id);

            return result;
        }

        public Genero BorrarGenero(int? id)
        {
            var result = this.IGeneroService.BorrarGenero(id);

            return result;
        }

    }
}
