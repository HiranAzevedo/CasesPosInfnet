using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base(nameof(ProjetoModeloDDD))
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<String>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<String>().Configure(p => p.HasMaxLength(100));

        }

        public override int SaveChanges()
        {
            /* Quando for verificar se houve mudança nas entidades, quando estiver inserindo, dizer que é a data atual. Quando for atualização, dizer que não houve mudança na data, que a data atual é uma data de modificação, mas estamos salvando em banco a de criação, que não se altera */
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Perfil> Perfil { get; set; }

        public DbSet<Conta> Conta { get; set; }

        public DbSet<Comentario> Comentario { get; set; }

        public DbSet<Publicacao> Publicacao { get; set; }
    }
}
