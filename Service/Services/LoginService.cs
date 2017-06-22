using DataAccessLayer;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private AlCineEntities db = new AlCineEntities();

        public bool ValidarUsuario(Usuario usuario)
        {
            Usuario usuarioValido = db.Usuarios.Find(usuario.NombreUsuario, usuario.Password); // revisar busqueda
            bool result=false;
            if (usuarioValido != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
