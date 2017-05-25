namespace SisAcad.Persistencia.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SisAcad.Persistencia.SisAcadDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //Padrão (se omitido): false - permite perda de dados em colunas - por exemplo - reduz coluna tamanho 100 para 80 sem questionar
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SisAcad.Persistencia.SisAcadDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
