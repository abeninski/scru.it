using Data;
using Model;
using Services.Contracts;
using System.Collections.Generic;
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
            return postService.GetAll();
        }

    }
}
