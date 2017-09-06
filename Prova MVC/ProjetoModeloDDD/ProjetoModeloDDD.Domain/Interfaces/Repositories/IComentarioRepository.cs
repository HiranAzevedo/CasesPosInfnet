using ProjetoModeloDDD.Domain.Entities;
using System;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IComentarioRepository : IRepositoryBase<Comentario>, IDisposable
    {
    }
}
