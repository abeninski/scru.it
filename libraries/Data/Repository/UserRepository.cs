using Model;
using System.Data.Entity;

namespace Data.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
