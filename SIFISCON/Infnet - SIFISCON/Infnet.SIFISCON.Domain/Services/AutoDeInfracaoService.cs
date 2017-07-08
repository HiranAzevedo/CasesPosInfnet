using Infnet.SIFISCON.Domain.Entities;
using Infnet.SIFISCON.Domain.Interfaces.Repositories;

namespace Infnet.SIFISCON.Domain.Services
{
    public class AutoDeInfracaoService : ServiceBase<AutoDeInfracao>
    {
        private readonly IRepositoryBase<AutoDeInfracao> _autoDeInfracaoRepository;

        public AutoDeInfracaoService(IRepositoryBase<AutoDeInfracao> repository) : base(repository)
        {
            _autoDeInfracaoRepository = repository;
        }
    }
}
