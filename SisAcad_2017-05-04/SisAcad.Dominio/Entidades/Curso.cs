using System.Collections.Generic;

namespace SisAcad.Dominio.Entidades
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Professor> Professores { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
        
        public Curso()
        {
            Professores = new List<Professor>();
            Turmas = new List<Turma>();
        }
    }
}