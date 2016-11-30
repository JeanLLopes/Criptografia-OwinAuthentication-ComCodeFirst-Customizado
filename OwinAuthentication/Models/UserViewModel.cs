using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwinAuthentication.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}