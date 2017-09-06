using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Entities
{
    public class Publicacao
    {
        public int IdPublicacao { get; set; }

        public int IdPerfil { get; set; }

        public string Conteudo { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}
