
using Data.Repository.Base;
using Model;
using Services.Contracts;
namespace Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }
    }
}
