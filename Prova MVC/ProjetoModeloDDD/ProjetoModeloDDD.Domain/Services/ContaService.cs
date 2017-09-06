using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ContaService : ServiceBase<Conta>, IContaService
    {
        private readonly IContaRepository ContaRepository;

        public ContaService(IContaRepository repository) : base(repository)
        {
            ContaRepository = repository;
        }
    }
}
