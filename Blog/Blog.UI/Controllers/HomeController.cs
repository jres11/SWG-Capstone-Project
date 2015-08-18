using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.BLL;
using Blog.MODELS;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Blogs()
        {
            var operations = new BlogOperations();
            
            return View(operations.GetAllBlogEntries());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CreateBlogEntry()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult BlogSummary()
        {
            return View();
        }

        //FULL ENTRY VIEW TO BE CREATED//
        public ActionResult FullBlogEntry()
        {
            return View();
        }

    }
}