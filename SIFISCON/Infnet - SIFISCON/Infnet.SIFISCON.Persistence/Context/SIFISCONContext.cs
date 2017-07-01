using Infnet.SIFISCON.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infnet.SIFISCON.Persistence.Context
{
    public class SIFISCONContext : DbContext
    {
        public SIFISCONContext() : base("DefaultConnection")
        { }

        public DbSet<AutoDeInfracao> AutoDeInfracoes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<Processo> Processos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
