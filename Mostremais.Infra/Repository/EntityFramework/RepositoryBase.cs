using System.Collections.Generic;
using Mostremais.Domain.Interface;
using Mostremais.Infra.Context;
using System.Linq;
using System.Data.Entity;
using System;

namespace Mostremais.Infra.Repository.EntityFramework
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ApplicationContextDb Db = new ApplicationContextDb();

        public RepositoryBase()
        {
            Db.Database.Log = GravaLog;    
        }

        public void GravaLog(string sql)
        {
            Console.WriteLine("Comando SQL: " + sql);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Delete(TEntity Entity)
        {
            Db.Set<TEntity>().Remove(Entity);
            Db.SaveChanges();
        }

        public TEntity GetById(int EntityId)
        {
            return Db.Set<TEntity>().Find(EntityId);
        }

        public void Insert(TEntity Entity)
        {
            Db.Set<TEntity>().Add(Entity);
            Db.SaveChanges(); 
        }

        public void Update(TEntity Entity)
        {
            Db.Entry(Entity).State = EntityState.Modified;
            Db.SaveChanges(); 
        }
         
    }
}
