using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Perfil
    {
        [Key, ForeignKey(nameof(Conta))]
        public int IdConta { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Local { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
