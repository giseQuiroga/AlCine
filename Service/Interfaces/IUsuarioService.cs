using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        List<Usuario> ListarUsuario();

        Usuario ObtenerDetalle(int? id);

        Usuario EditarUsuario(int? id);

        Usuario BorrarUsuario(int? id);

    }
}
