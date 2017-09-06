using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Publicacao
    {
        [Key]
        public int IdPublicacao { get; set; }

        public int IdPerfil { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey(nameof(IdPerfil))]
        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}
