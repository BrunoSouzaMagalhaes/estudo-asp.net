using System.Collections.Generic;
using Mostremais.Domain.Interface;
using Mostremais.Infra.Repository.EntityFramework;

namespace Mostremais.Application
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class
    {
        protected  IRepository<TEntity> Repository; 
       
        public void Delete(TEntity Entity)
        {
            Repository.Delete(Entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public TEntity GetById(int EntityId)
        {
            return Repository.GetById(EntityId);
        }

        public void Insert(TEntity Entity)
        {
            Repository.Insert(Entity);
        }

        public void Update(TEntity Entity)
        {
            Repository.Update(Entity);
        }
    }
}
