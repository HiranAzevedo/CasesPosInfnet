using MusicStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MusicStore.MVC.ApplicationService
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            this.serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            serviceBase.Add(obj);
        }

        public void Dispose()
        {
            serviceBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return serviceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            serviceBase.Update(obj);
        }
    }
}