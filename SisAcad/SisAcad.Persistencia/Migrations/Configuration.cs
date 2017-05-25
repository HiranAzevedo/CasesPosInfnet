namespace SisAcad.Persistencia.Migrations
{
    using Dominio.Entidades;
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
            Professor p1 = new Professor();
            p1.Nome = "Carlos Pivotto";

            Professor p2 = new Professor();
            p2.Nome = "Aquino Botelho";

            Curso c1 = new Curso();
            c1.Descricao = "Eng. Softw. .NET";
            c1.Professores.Add(p1);
            c1.Professores.Add(p2);

            Curso c2 = new Curso();
            c2.Descricao = "Eng. Softw. Java";
            c2.Professores.Add(p1);
            c2.Professores.Add(p2);

            context.Cursos.Add(c1);
            context.Cursos.Add(c2);
        }
    }
}
