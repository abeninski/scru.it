using Model;

namespace Data.Repository
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(IDataContext context)
            : base(context)
        {

        }
    }
}
