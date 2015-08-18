using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.BLL;
using Blog.MODELS;

namespace Blog.UI.Controllers
{
    public class BlogStuffController : ApiController
    {
        public List<BlogEntry> Get()
        {
            var blogOp = new BlogOperations();
            return blogOp.GetAllBlogEntries();
        }

        public BlogEntry Get(int id)
        {
            var blogOp = new BlogOperations();
            return blogOp.GetBlogEntry(id);
        }

        public HttpResponseMessage Delete(int id)
        {
            var blogOp = new BlogOperations();
            blogOp.DeleteBlogEntry(id);

            var response = Request.CreateResponse(HttpStatusCode.NoContent, id);

            return response;
        }

        public HttpResponseMessage Post(BlogEntry blogEntry)
        {
            var blogOp = new BlogOperations();
            blogOp.CreateBlogEntry(blogEntry);

            var response = Request.CreateResponse(HttpStatusCode.Created, blogEntry);

            return response;
        }

        public HttpResponseMessage Put(BlogEntry blogEntry)
        {
            var blogOp = new BlogOperations();
            blogOp.EditBlogEntry(blogEntry);

            var response = Request.CreateResponse(HttpStatusCode.OK, blogEntry);

            return response;
        }

        
    }
}
