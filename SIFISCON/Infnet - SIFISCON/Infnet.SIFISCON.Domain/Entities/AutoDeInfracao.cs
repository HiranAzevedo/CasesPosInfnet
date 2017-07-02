using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infnet.SIFISCON.Domain.Entities
{
    public class AutoDeInfracao
    {
        [Key, ForeignKey(nameof(Processo))]
        public int Id { get; set; }

        public int Gravidade { get; set; }

        public bool Atenuante { get; set; }

        public bool Agravante { get; set; }

        public decimal Multa { get; set; }

        public virtual Processo Processo { get; set; }
    }
}
