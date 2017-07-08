using Infnet.SIFISCON.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infnet.SIFISCON.Domain.Interfaces.Repositories;

namespace Infnet.SIFISCON.Domain.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>
    {
        private IRepositoryBase<Fornecedor> _fornecedorRepository;

        public FornecedorService(IRepositoryBase<Fornecedor> repository) : base(repository)
        {
            _fornecedorRepository = repository;
        }
    }
}
