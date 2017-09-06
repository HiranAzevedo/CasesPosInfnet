using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PublicacaoService : ServiceBase<Publicacao>, IPublicacaoService
    {
        private readonly IPublicacaoRepository PublicacaoRepository;

        public PublicacaoService(IPublicacaoRepository repository) : base(repository)
        {
            PublicacaoRepository = repository;
        }
    }
}
