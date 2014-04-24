using Model;

namespace Data.Repository
{
    public class UserScrewRepository : Repository<UserScrew>
    {
        public UserScrewRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
