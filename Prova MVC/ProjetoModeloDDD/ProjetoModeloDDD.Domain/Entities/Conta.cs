using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Conta
    {
        [Key]
        public int IdConta { get; set; }

        public string NomeUsuario { get; set; }

        public string Senha { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
