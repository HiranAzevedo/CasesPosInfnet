using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PerfilService : ServiceBase<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository PerfilRepository;

        public PerfilService(IPerfilRepository repository) : base(repository)
        {
            PerfilRepository = repository;
        }
    }
}
