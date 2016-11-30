using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OwinAuthentication.Models
{
    public class AccountViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(6, ErrorMessage ="A senha deverá ter 6 digitos")]
        public string Password { get; set; }

        [Required]
        public string Cpf { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="As senhas não batem")]
        public string ConfirmPassword { get; set; }
    }
}