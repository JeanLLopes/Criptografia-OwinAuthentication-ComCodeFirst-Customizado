

using Microsoft.Owin.Security;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using OwinAutentication.Acessos.Lgroup.Infra.Security;
using OwinAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

//Para se autenticar via FormsAuthentication
//Temos que usar o seguinte Namespace:
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace OwinAuthentication.Controllers
{
    //Esta classe não entrará na regra de authenticação
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthenticationManager _authenticationManager;
        SignInManager<Usuario, string> _signInManager;

        public LoginController()
        {
            //Gerenciador de Login
            _authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            _signInManager = new AppSignInManager(_authenticationManager);
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Validando a origem.
        [HttpPost]
        public  async Task<ActionResult> Index(LoginModel login, string returnUrl)
        {
            //Para logar-se precisamos usar a classe FormsAuthentication para o pipeline que usa
            //O System.Web

            //Estamos verificando se o usuario existe
            var user = await _signInManager
                .UserManager
                .FindAsync(login.User, login.Password);

            if (user != null)
            {
                //Login
                //Iremos colocar todos os itens do user no AuthorizationManager
                await _signInManager.SignInAsync(user, true, true);

                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.loginResult = "Usuário ou senha inválidos";
            }

            return View();
        }

        public ActionResult LogOff() {

            _authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}