using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class ComentarioAppService : AppServiceBase<Comentario>, IComentarioAppService
    {
        private readonly IComentarioService ComentarioService;

        public ComentarioAppService(IComentarioService serviceBase) : base(serviceBase)
        {
            ComentarioService = serviceBase;
        }
    }
}
