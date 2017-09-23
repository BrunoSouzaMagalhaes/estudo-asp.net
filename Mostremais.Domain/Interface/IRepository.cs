using System.Collections.Generic;

namespace Mostremais.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Insert(TEntity Entity);
        void Update(TEntity Entity);
        IEnumerable<TEntity> GetAll(); 
        TEntity GetById(int EntityId);
        void Delete(TEntity Entity);
    }
}
