using Microsoft.AspNet.Identity;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinAutentication.Acessos.Lgroup.Infra.Data
{
    public class UsuarioRepository : IUserStore<Usuario, int>
    {
        public Task CreateAsync(Usuario user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Usuario user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
