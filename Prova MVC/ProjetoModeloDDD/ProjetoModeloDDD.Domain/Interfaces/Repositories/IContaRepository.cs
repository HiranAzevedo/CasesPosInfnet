using ProjetoModeloDDD.Domain.Entities;
using System;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IContaRepository : IRepositoryBase<Conta>, IDisposable
    {
    }
}
