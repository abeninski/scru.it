
using Data.Repository.Base;
using Model;
using Services.Base;
using Services.Contracts;
namespace Services
{
    public class PostService : Service<Post>, IPostService
    {
        public PostService(IRepository<Post> postRepository)
            : base(postRepository)
        {

        }
    }
}
