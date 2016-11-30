using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(OwinAuthentication.Startup))]

namespace OwinAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Install-package Microsoft.Owin.host.SystemWeb
            //Usamos para integrar o IIS com o Owin

            //Install-package Microsoft.Owin.security
            //Para usar middlewares e classes de segurança no owin

            //Install-package Microsoft.Owin.security.Cookies
            //Para usarmos cookies

            //Todo Mundo!!!
            //Tem que se autenticar
            GlobalFilters.Filters.Add(new AuthorizeAttribute());


            //Estamos criando um middleware
            //Este middleware será responsavel por autentica a nossa aplicação
            //usando cookies

            var options = new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieName = "LgroupCookie",
                LoginPath = new PathString("/Login/Index"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnValidateIdentity = (x) => {
                        return Task.FromResult(0);
                    }
                }
            };

            app.UseCookieAuthentication(options);
        }
    }
}
