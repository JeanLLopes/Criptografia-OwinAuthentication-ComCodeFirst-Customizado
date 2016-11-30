using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using OwinAutentication.Acessos.Lgroup.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinAutentication.Acessos.Lgroup.Infra.Security
{
    public class AppUserManager :
        UserManager<Usuario, int>
    {
        public AppUserManager() 
            : base(new UsuarioRepository())
        {
            //PARA VALIDAR O USUARIO VAMOS USAR O SEGUINTE ITEM
            this.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true
            };



            this.PasswordHasher = null;

        }
    }
}
