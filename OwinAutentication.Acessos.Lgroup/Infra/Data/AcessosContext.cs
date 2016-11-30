using Microsoft.AspNet.Identity.EntityFramework;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using System.Data.Entity;

namespace OwinAutentication.Acessos.Lgroup.Infra.Data
{
    public class AcessosContext:DbContext
    {
        //Estamos setando a string de conexão do webConfig
        //com o name AAIdentity1
        public AcessosContext() 
            : base("AAIdentity2")
        {        }
    }
}
