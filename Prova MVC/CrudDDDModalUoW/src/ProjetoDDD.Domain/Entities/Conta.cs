using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Entities
{
    public class Conta
    {
        public int IdConta { get; set; }

        public string NomeUsuario { get; set; }

        public string Senha { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
