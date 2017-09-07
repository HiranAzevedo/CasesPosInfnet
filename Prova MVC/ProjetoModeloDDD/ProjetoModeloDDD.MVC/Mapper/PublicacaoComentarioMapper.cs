using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.Mapper
{
    public class PublicacaoComentarioMapper
    {
        public static IEnumerable<Comentario> ExtractComentariosFromViewModel(PublicacaoComentarioViewModel viewModel)
        {
            return viewModel.Comentarios;
        }

        public static Publicacao ExtractPublicacaoFromViewModel(PublicacaoComentarioViewModel viewModel)
        {
            return new Publicacao
            {
                Conteudo = viewModel.PublicacaoText,
                IdPublicacao = viewModel.IdPublicacao,
                Comentario = (ICollection<Comentario>)viewModel.Comentarios,
                IdPerfil = viewModel.IdPerfil,
            };
        }

        public static PublicacaoComentarioViewModel BuildViewModelFromPublicacaoComentario(Publicacao publicacao, IEnumerable<Comentario> comentario)
        {
            return new PublicacaoComentarioViewModel
            {
                Comentarios = comentario,
                IdPerfil = publicacao.IdPerfil,
                IdPublicacao = publicacao.IdPublicacao,
                PublicacaoText = publicacao.Conteudo
            };
        }
    }
}