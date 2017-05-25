using SisAcad.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SisAcad.Persistencia.Config
{
    public class TurmaConfig: EntityTypeConfiguration<Turma>
    {
        public TurmaConfig()
        {
            ToTable("Turma");
            HasKey(t => t.TurmaId);

            /*
            Na entidade Turma, a propriedade Curso é obrigatória:
            */
            HasRequired(t => t.Curso)
                .WithMany() //Curso pode ter muitas turmas; parâmetro é opcional
                .Map(m => m.MapKey("CursoId")); // A chave estrangeira em turma é CursoId

            /*
            Propriedade Professor também é obrigatória:
            */
            HasRequired(t => t.Professor)
                .WithMany()
                .Map(m => m.MapKey("ProfessorId"));


        }
    }
}
