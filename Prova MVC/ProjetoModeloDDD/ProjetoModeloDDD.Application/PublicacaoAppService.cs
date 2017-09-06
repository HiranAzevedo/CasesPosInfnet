using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class PublicacaoAppService : AppServiceBase<Publicacao>, IPublicacaoAppService
    {
        private readonly IPublicacaoService publicacaoService;

        public PublicacaoAppService(IPublicacaoService serviceBase) : base(serviceBase)
        {
            publicacaoService = serviceBase;
        }
    }
}
