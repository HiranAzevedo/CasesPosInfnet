using Infnet.SIFISCON.Domain.Entities;
using Infnet.SIFISCON.Domain.Interfaces.Repositories;

namespace Infnet.SIFISCON.Domain.Services
{
    class EnderecoService : ServiceBase<Endereco>
    {
        private readonly IRepositoryBase<Endereco> _enderecoRepository;

        public EnderecoService(IRepositoryBase<Endereco> repository) : base(repository)
        {
            _enderecoRepository = repository;
        }
    }
}
