using MusicStore.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicStore.DataBase.Context
{
    public class MusicStoreContext : DbContext
    {

        public MusicStoreContext() : base("MusicStoreDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(x => x.IsKey());
            modelBuilder.Properties<String>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties<String>().Configure(x => x.HasMaxLength(100));

        }


        public DbSet<Album> Album { get; set; }

        public DbSet<Artist> Artist { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
    }
}
