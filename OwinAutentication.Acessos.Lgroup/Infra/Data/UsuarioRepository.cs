using Microsoft.AspNet.Identity;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinAutentication.Acessos.Lgroup.Infra.Data
{
    public class UsuarioRepository : IUserPasswordStore<Usuario, int>, IQueryableUserStore<Usuario,int>
    {
        private AcessosContext _acessosContext;

        public UsuarioRepository()
        {

        }



        public IQueryable<Usuario> Users
        {
            get
            {
                //PARA RETORNAR ALGO NO MINIMO TEMOS QUE DAR UM TOLIST
                //NESTE CASO VAMOS USAR O USER ASQUERYABLE
                return _acessosContext.Usuarios.AsQueryable();
            }
        }

        public async Task CreateAsync(Usuario user)
        {
            _acessosContext.Usuarios.Add(user);
            await _acessosContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario user)
        {
            _acessosContext.Usuarios.Remove(user);
            await _acessosContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _acessosContext.Dispose();
        }

        public Task<Usuario> FindByIdAsync(int userId)
        {
            return _acessosContext.Usuarios.FindAsync(userId);
        }

        public async Task<Usuario> FindByNameAsync(string userName)
        {
            return await Task.Run(() =>
            {
                return _acessosContext.Usuarios.Single(x => x.UserName.Equals(userName));
            });
        }

        public async Task<string> GetPasswordHashAsync(Usuario user)
        {
            return await Task.Run(() =>
            {
                return user.HashPassword;
            });
        }

        public async Task<bool> HasPasswordAsync(Usuario user)
        {
            return await Task.Run(() =>
            {
                return !string.IsNullOrWhiteSpace(user.HashPassword);
            });
        }

        public  Task SetPasswordHashAsync(Usuario user, string passwordHash)
        {
            user.HashPassword = passwordHash;
            return Task.FromResult<object>(null);
        }

        public async Task UpdateAsync(Usuario user)
        {
            _acessosContext.Entry(user).State = EntityState.Modified;
            await _acessosContext.SaveChangesAsync();
        }
    }
}
