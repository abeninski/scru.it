
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace Data
{
    public interface IDataContext
    {
        int SaveChanges();

        DbSet<T> Set<T>()
            where T : class;

        DbEntityEntry<T> Entry<T>(T entity)
            where T : class;
    }
}
