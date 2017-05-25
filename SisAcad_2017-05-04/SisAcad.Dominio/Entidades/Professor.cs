using System.Collections.Generic;

namespace SisAcad.Dominio.Entidades
{
    public class Professor : Pessoa
    {
        public int ProfessorId { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }

        public Professor()
        {
            Turmas = new List<Turma>();
            Cursos = new List<Curso>();
        }
    }
}