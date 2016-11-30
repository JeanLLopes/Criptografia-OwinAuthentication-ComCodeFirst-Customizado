using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NAMESPACE PARA CRIAÇÃO DE HACSH
using System.Security.Cryptography;

namespace OwinAutentication.Acessos.Lgroup.Infra.Helpers
{
    public class HashHelper
    {
        private readonly HashAlgorithm _algorithm;

        public HashHelper(HashAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }


        public string Crypto(string password)
        {
            // passo para byte
            var bytes = Encoding.UTF8.GetBytes(password);

            //CONVERTE PARA HASH
            var hash = _algorithm.ComputeHash(bytes);

            // COMVERTE OS BYTES PARA BASE64
            return Convert.ToBase64String(hash);
        }


        //VERIFICA SE O PASSWORD ESTA CORRETO COMPARANDO ELE COM O RESULTADO DA CRIPTOGRAFIA
        public bool VerifyHash(string password, string hash)
        {
            return Crypto(password).Equals(hash);
        }
    }
}
