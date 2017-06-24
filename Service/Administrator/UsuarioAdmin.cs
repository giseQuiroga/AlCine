using System.Collections.Generic;
using Service.Interfaces;
using DataAccessLayer;


namespace Service.Administrator
{
    public class UsuarioAdmin
    {

        protected IUsuarioService iUsuarioService;

        public UsuarioAdmin(IUsuarioService _iUsuarioService)
        {
            this.iUsuarioService = _iUsuarioService;
        }

        public List<Usuario> ListarUsuario()
        {
            var result = this.iUsuarioService.ListarUsuario();

            return result;
        }

        public Usuario ObtenerDetalle(int? id)
        {
            var result = this.iUsuarioService.ObtenerDetalle(id);

            return result;
        }

        public Usuario EditarUsuario(int? id)
        {
            var result = this.iUsuarioService.EditarUsuario(id);

            return result;
        }

        public Usuario BorrarUsuario(int? id)
        {
            var result = this.iUsuarioService.BorrarUsuario(id);

            return result;
        }
    }
}
