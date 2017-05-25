using SisAcad.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SisAcad.Persistencia.Config
{
    public class CursoConfig : EntityTypeConfiguration<Curso>
    {
        public CursoConfig()
        {
            /*
            Método ToTable - define qual deve ser o nome dado à tabela no banco de dados.
            */
            ToTable("Curso");

            /*
            Definir explicitamente qual será a chave primária no banco:
            */
            HasKey(c => c.CursoId);

            /*
            A propriedade Descricao será um campo de 300 caracteres no máximo e será NOT NULL
            */
            Property(c => c.Descricao).HasMaxLength(300).IsRequired();

            /*
            Definição da relação m:n entre Curso e Professor:
            */
            HasMany(c => c.Professores) //Um curso possui uma lista de professores
                .WithMany(p => p.Cursos) //E cada professor do curso possui uma lista de cursos
                .Map(m => //O relacionamento entre Curso e Professor será mapeado numa terceira tabela
                {
                    /*
                    Como este mapeamento está sendo feito a partir de Curso para professor, o lado ESQUERDO do relacionamento é Curso. Professor é o lado DIREITO do relacionamento
                    */
                    m.MapLeftKey("CursoId"); //O nome da chave estrangeira oriunda de Curso será CursoId
                    m.MapRightKey("ProfessorId"); //O nome da chave estrangeira oriunda de professor será ProfessorId
                    m.ToTable("CursoProfessor"); //Nome da tabela de relacionamento.
                });
        }
    }
}
