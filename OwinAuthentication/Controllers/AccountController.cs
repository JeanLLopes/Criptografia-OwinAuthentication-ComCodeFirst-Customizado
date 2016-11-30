using Microsoft.AspNet.Identity;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using OwinAutentication.Acessos.Lgroup.Infra.Security;
using OwinAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OwinAuthentication.Controllers
{
    public class AccountController : Controller
    {
        private AppUserManager _appUserManager;

        public AccountController()
        {
            _appUserManager = new AppUserManager();
        }

        // GET: Account
        public ActionResult Index()
        {
            var model = _appUserManager.Users;

            IQueryable<UserViewModel> vm  = model.Select(x => new UserViewModel() {
                Cpf = x.Cpf,
                Email = x.Email,
                Senha = x.PasswordHash,
                UserName = x.UserName
            });

            return View(vm.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var model = new Usuario()
                {
                    Cpf = account.Cpf,
                    Email = account.Email,
                    UserName = account.UserName
                };

                //O Asp.Net Identity trabalha na maioria das vezes com métodos assincronos
                //Ele não retorna erro, e sim um objeto especificando o status do command
                var identityResult =  await _appUserManager.CreateAsync(model, account.Password);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddError(identityResult);
                    return View();
                }
            }
            return View();
        }

        private void AddError(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                //Estamos colocando uma lista de erros no estado da página
                //Com controles Helper iremos seleciona-los caso haja um erro
                ModelState.AddModelError("", item);
            }
        }
    }
}