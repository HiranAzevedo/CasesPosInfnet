using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ComentarioService : ServiceBase<Comentario>, IComentarioService
    {
        private readonly IComentarioRepository ComentarioRepository;

        public ComentarioService(IComentarioRepository repository) : base(repository)
        {
            ComentarioRepository = repository;
        }
    }
}
