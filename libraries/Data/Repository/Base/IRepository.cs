using Model.Base;
using System;
using System.Data.Entity;

namespace Data.Repository.Base
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        DbSet<T> Query();
        ExtendedQuery<T> ExtendedQuery();
        T GetByID(object id);
        void Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Detach(T entity);
        void Update(T entity);
    }
}
