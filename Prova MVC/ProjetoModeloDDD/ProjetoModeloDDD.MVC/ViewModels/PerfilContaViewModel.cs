using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PerfilContaViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string SobreNome { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Local { get; set; }

        [Key]
        [Required]
        public int IdConta { get; set; }
    }
}