using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class PerfilAppService : AppServiceBase<Perfil>, IPerfilAppService
    {
        private readonly IPerfilService PerfilService;

        public PerfilAppService(IPerfilService serviceBase) : base(serviceBase)
        {
            PerfilService = serviceBase;
        }
    }
}
