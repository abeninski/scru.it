
using Data.Repository.Base;
using Model.Base;
using System;
using System.Linq;

namespace Services.Base
{
    public class Service<T> : IService<T>
        where T : class, IEntity
    {
        protected IRepository<T> repository { get; private set; }

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public IQueryable<T> GetAllQuery()
        {
            return this.repository.Query();
        }

        public System.Collections.Generic.List<T> GetAll()
        {
            return this.repository.Query().ToList();
        }

        public T GetByID(Guid id)
        {
            return this.repository.GetByID(id);
        }

        public void Save(T entity)
        {
            if (entity.Id == 0)
            {
                this.repository.Add(entity);
            }
            else
            {
                this.repository.Update(entity);
            }
        }

        public void Delete(T entity)
        {
            this.repository.Delete(entity);
        }

        public void Delete(Guid id)
        {
            this.repository.Delete(id);
        }
    }
}
