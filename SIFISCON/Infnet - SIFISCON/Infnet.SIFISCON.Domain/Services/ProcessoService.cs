using Infnet.SIFISCON.Domain.Entities;
using Infnet.SIFISCON.Domain.Interfaces.Repositories;

namespace Infnet.SIFISCON.Domain.Services
{
    public class ProcessoService : ServiceBase<Processo>
    {
        private IRepositoryBase<Processo> _processoRepository;

        public ProcessoService(IRepositoryBase<Processo> repository) : base(repository)
        {
            _processoRepository = repository;
        }
    }
}
