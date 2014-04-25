
using System;
using System.Collections.Generic;
using System.Linq;
namespace Services.Base
{
    public interface IService<T>
        where T : class
    {
        IQueryable<T> GetAllQuery();
        List<T> GetAll();
        T GetByID(int id);
        void Save(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
