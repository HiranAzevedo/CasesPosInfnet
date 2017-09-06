namespace ProjetoDDD.Domain.Entities
{
    public class Perfil
    {
        public int IdConta { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Local { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
