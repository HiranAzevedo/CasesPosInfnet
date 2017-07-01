using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infnet.SIFISCON.Domain.Entities
{
    public class Processo
    {
        [Key]
        public int Id { get; set; }

        public string RelatoFiscalizacao { get; set; }

        public DateTime DataRelato { get; set; }

        public string FiscalResponsavel { get; set; }

        [ForeignKey(nameof(Fornecedor))]
        public int FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        [ForeignKey(nameof(AutoDeInfracao))]
        public int AutoDeInfracaoId { get; set; }

        public virtual AutoDeInfracao AutoDeInfracao { get; set; }
    }
}