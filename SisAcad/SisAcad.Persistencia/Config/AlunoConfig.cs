using SisAcad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcad.Persistencia.Config
{
    public class AlunoConfig : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            ToTable("Aluno");
            HasKey(a => a.AlunoId);

            //Relação 1:N -> Aluno PRECISA TER uma turma e 1 turma pode ter N alunos
            HasRequired(a => a.Turma)
                .WithMany()
                .Map(m => m.MapKey("TurmaId"));

            //Relação 1:1 -> Aluno x Usuário
            HasRequired(a => a.Usuario)
                .WithRequiredPrincipal();

        }
    }
}

