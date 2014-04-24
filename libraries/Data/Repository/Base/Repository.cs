using Data.Repository.Base;
using Model.Base;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected DbSet<T> DBSet { get; set; }
        protected IDataContext Context { get; set; }

        public Repository(IDataContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DBSet = this.Context.Set<T>();
        }

        public DbSet<T> Query()
        {
            return this.DBSet;
        }

        public T GetByID(object id)
        {
            return this.DBSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DBSet.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DBSet.Attach(entity);
                this.DBSet.Remove(entity);
            }
        }

        public void Delete(object id)
        {
            T entity = this.GetByID(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DBSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public ExtendedQuery<T> ExtendedQuery()
        {
            return new ExtendedQuery<T>(this.DBSet);
        }
    }
}
