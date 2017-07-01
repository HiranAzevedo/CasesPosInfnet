using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.SIFISCON.Domain.Entities
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string InscricaoMunicipal { get; set; }

        public decimal ReceitaBruta { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Processo> Processos { get; set; }
    }
}
