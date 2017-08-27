using MusicStore.DataBase.Context;
using MusicStore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicStore.DataBase.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected MusicStoreContext Db = new MusicStoreContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return Db.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Remove(int id)
        {
            Db.Entry(Db.Set<TEntity>().Find(id)).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
