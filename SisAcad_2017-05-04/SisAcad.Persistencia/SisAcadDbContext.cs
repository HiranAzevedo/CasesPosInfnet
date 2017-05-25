using SisAcad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcad.Persistencia
{
    public class SisAcadDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public SisAcadDbContext() : base("SisAcad")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Todas as propriedades strings dos tipos refletidos no banco serão colunas do tipo varchar (não mais 'nvarchar') e com tamanho máximo padrão 100 (não mais 'max')
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")
                                    .HasMaxLength(100));

            //Impõe chave primária obrigatoriamente no padrão ClasseId, não aceitando mais id/Id;
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

        }
    }
}
