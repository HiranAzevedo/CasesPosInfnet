using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoDDD.Domain.Interfaces.Service
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        bool SaveChanges();
    }
}
