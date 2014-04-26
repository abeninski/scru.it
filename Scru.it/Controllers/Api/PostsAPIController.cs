using Data;
using Model;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SiteBuilder.Web.Controllers
{
    public class PostsApiController : ApiController
    {
        private IPostService postService;
        private IDataContext _dataContext;
        public PostsApiController(IDataContext dataContext, IPostService postService)
        {
            this.postService = postService;
            this._dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return postService.GetAll().OrderByDescending(current => current.CreatedOn);
        }

        [HttpPost]
        public Post Post(Post post)
        {
            this.postService.Save(post);

            this._dataContext.SaveChanges();

            return post;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.postService.Delete(id);
            this._dataContext.SaveChanges();
        }

        [HttpPut]
        public void Put(int id, Post post)
        {
            var dbPost = this.postService.GetByID(id);

            dbPost.ScrewItCount = post.ScrewItCount;
            dbPost.ScrewYouCount = post.ScrewYouCount;

            this.postService.Save(dbPost);
            this._dataContext.SaveChanges();
        }
    }
}
