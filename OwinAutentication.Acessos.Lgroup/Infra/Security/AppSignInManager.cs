using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;

using OwinAutentication.Acessos.Lgroup.DomainModel;
using Microsoft.AspNet.Identity;

namespace OwinAutentication.Acessos.Lgroup.Infra.Security
{
    public class AppSignInManager
        : SignInManager<Usuario, int>
    {
        //Precisamos pegar os objetos no banco de dados
        //e inseri-los no objeto de autenticação do Owin
        //Quem é o objeto de autenticação do owin??
        //Resposta: IAuthenticationManager
        public AppSignInManager(IAuthenticationManager authenticationManager) 
            : base(new AppUserManager(), authenticationManager)
        {
        }
    }
}
