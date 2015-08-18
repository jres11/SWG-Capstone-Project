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
    public class StaticPageController : ApiController
    {
        public HttpResponseMessage Post(StaticEntry staticEntry)
        {
            var blogOp = new BlogOperations();
            blogOp.CreateStaticEntry(staticEntry);

            var response = Request.CreateResponse(HttpStatusCode.Created, staticEntry);

            return response;
        }

        //get title and url call from db
    }
}
