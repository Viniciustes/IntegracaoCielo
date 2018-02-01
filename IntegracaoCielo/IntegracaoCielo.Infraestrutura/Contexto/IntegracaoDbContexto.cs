using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IntegracaoCielo.Infraestrutura.Contexto
{
    public class IntegracaoDbContexto : DbContext
    {
        public IntegracaoDbContexto() : base("IntegracaoDb")
        {
            Database.SetInitializer<IntegracaoDbContexto>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}