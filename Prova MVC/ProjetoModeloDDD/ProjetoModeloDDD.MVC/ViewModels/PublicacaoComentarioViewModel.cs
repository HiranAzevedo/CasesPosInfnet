using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PublicacaoComentarioViewModel
    {
        public int IdPerfil { get; set; }

        public IEnumerable<Comentario> Comentarios { get; set; }

        [Key]
        public int IdPublicacao { get; set; }

        public string PublicacaoText { get; set; }
    }
}