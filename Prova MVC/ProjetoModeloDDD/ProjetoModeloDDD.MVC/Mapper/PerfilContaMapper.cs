using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Mapper
{
    public class PerfilContaMapper
    {
        public static Perfil ExtractPerfilFromViewModel(PerfilContaViewModel viewModel)
        {
            var perfil = new Perfil
            {
                IdConta = viewModel.IdConta,
                Local = viewModel.Local,
                Nome = viewModel.Nome,
                Sobrenome = viewModel.SobreNome,

            };
            return perfil;
        }

        public static Conta ExtractContaFromViewModel(PerfilContaViewModel viewModel)
        {
            var conta = new Conta
            {
                IdConta = viewModel.IdConta,
                NomeUsuario = viewModel.NomeUsuario,
                Senha = viewModel.Senha
            };

            return conta;
        }


        public static PerfilContaViewModel BuildViewModelFromContaPerfil(Conta conta, Perfil perfil)
        {
            var viewModel = new PerfilContaViewModel
            {
                IdConta = conta.IdConta,
                Local = perfil.Local,
                Nome = perfil.Nome,
                NomeUsuario = conta.NomeUsuario,
                Senha = conta.Senha,
                SobreNome = perfil.Sobrenome
            };

            return viewModel;
        }
    }
}