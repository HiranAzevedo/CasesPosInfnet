using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class ContaAppService : AppServiceBase<Conta>, IContaAppService
    {
        private readonly IContaService ContaService;

        public ContaAppService(IContaService serviceBase) : base(serviceBase)
        {
            ContaService = serviceBase;
        }
    }
}
