using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicStore.Data.Context
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext() : base("MusicStoreConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
