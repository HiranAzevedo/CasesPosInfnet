using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }

        public string Text { get; set; }

        public int IdPerfil { get; set; }

        [ForeignKey(nameof(IdPerfil))]
        public virtual Perfil Perfil { get; set; }

        public int IdPublicacao { get; set; }

        [ForeignKey(nameof(IdPublicacao))]
        public virtual Publicacao Publicacao { get; set; }
    }
}
