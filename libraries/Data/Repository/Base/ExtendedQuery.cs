
using Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
namespace Data.Repository.Base
{
    public class ExtendedQuery<T>
        where T : class, IEntity
    {
        protected IQueryable<T> query;
        public ExtendedQuery(DbSet<T> dbset)
        {
            this.query = dbset;
        }

        public ExtendedQuery<T> Include<TProperty>(Expression<Func<T, TProperty>> path)
        {
            this.query = this.query.Include<T, TProperty>(path);
            return this;
        }

        public ICollection<T> Fetch()
        {
            return this.query.ToList();
        }

        public T GetById(int id)
        {
            return this.query
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
