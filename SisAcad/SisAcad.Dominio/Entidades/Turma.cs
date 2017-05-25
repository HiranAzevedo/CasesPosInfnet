using System;
using System.Collections.Generic;

namespace SisAcad.Dominio.Entidades
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

        public Turma()
        {
            Alunos = new List<Aluno>();
        }
    }
}