using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OwinAutentication.Acessos.Lgroup.Infra.Helpers
{
    public class CustomPasswordHash : IPasswordHasher
    {
        private HashHelper _hashHelper;

        public CustomPasswordHash()
        {
            _hashHelper = new HashHelper(SHA512.Create());
        }


        public string HashPassword(string password)
        {
            return _hashHelper.Crypto(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (_hashHelper.VerifyHash(providedPassword,hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}
