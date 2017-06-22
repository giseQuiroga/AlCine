using DataAccessLayer;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Administrator
{
    public class LoginAdmin
    {
        protected ILoginService iLoginService;

        public LoginAdmin(ILoginService _iLoginService)
        {
            this.iLoginService = _iLoginService;
        }

        public bool ValidarUsuario(Usuario usuario) {
            var result = this.iLoginService.ValidarUsuario(usuario);
            return result;
        }
    }
}
