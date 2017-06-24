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
    public class UsuarioService : IUsuarioService
    {
        private AlCineEntities db = new AlCineEntities();

        public List<Usuario> ListarUsuario()
        {
            var usuario = db.Usuarios.Select(u => u);
            return usuario.ToList() ;
        }

        public Usuario ObtenerDetalle(int? id)
        {
            Usuario usuario = db.Usuarios.Find(id);

            return usuario;
        }

        public Usuario EditarUsuario(int? id)
        {
            Usuario usuario = db.Usuarios.Find(id);

            return usuario;
        }

        public Usuario BorrarUsuario(int? id)
        {
            Usuario usuario = db.Usuarios.Find(id);

            return usuario;
        }
    }
}
