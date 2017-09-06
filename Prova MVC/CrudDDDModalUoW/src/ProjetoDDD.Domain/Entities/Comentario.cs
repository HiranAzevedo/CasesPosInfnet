namespace ProjetoDDD.Domain.Entities
{
    public class Comentario
    {
        public int IdComentario { get; set; }

        public string Text { get; set; }

        public int IdPerfil { get; set; }

        public virtual Perfil Perfil { get; set; }

        public int IdPublicacao { get; set; }

        public virtual Publicacao Publicacao { get; set; }
    }
}
