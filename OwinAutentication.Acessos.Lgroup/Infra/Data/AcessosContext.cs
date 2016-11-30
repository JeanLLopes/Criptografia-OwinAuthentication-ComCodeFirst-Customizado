using Microsoft.AspNet.Identity.EntityFramework;
using OwinAutentication.Acessos.Lgroup.DomainModel;
using System.Data.Entity;


// RETIRAR O PLURALIZE
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OwinAutentication.Acessos.Lgroup.Infra.Data
{
    public class AcessosContext:DbContext
    {
        //Estamos setando a string de conexão do webConfig
        //com o name AAIdentity2
        public AcessosContext() : base("AAIdentity2")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //REMOVEMOS A PLURALIZAÇÃO DO METODO
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();


            base.OnModelCreating(modelBuilder);
        }
    }
}
