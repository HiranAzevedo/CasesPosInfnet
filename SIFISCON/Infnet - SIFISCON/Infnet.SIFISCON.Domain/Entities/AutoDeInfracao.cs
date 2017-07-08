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

        private decimal? Multa { get; set; }

        public virtual Processo Processo { get; set; }

        [NotMapped]
        private static decimal PenaBase => 500m;

        [NotMapped]
        private static decimal UFIR => 3m;

        public decimal ValorDaMulta()
        {
            if (Multa == null || Multa == default(decimal))
            {
                var ReceitaBruta = Processo.Fornecedor.ReceitaBruta;
                var valAgravante = Agravante ? 1m : 0m;
                var valAtenuante = Atenuante ? 0.33m : 1m;

                Multa = PenaBase + (((ReceitaBruta - 120000m) * 0.1m) + 120000m) * (UFIR * (valAgravante + valAtenuante) * Gravidade);
            }

            return Multa.Value;
        }
    }
}
