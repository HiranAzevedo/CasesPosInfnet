using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcad.Dominio.Entidades
{
    public class Aluno : Pessoa
    {
        public int AlunoId { get; set; }

        public virtual Turma Turma { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Aluno()
        {
            Usuario = new Usuario();
        }
    }
}
