using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DATA;
using Blog.MODELS;

namespace Blog.TEST
{
    class MockRepo : IBlogRepo
    {
        private static List<BlogEntry> Blogs { get; set; }
        private static List<StaticEntry> Static { get; set; }

        public MockRepo()
        {
            Blogs = new List<BlogEntry>();
            Static = new List<StaticEntry>();

            for (int i = 1; i < 6; i++)
            {
                Blogs.Add(new BlogEntry()
            {
                BlogID = i,
                DateOfPost = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(2),
                StartDate = DateTime.Now.Date,
                Title = "Fake Title" + i,
                PostContents = "Test Post" + i,
                StatusID = 1,
                UserID = "19faea31-fb63-4d55-b661-6884255d4d53"
            });
            }

            for (int i = 1; i < 4; i++)
            {
                Static.Add(new StaticEntry()
                {
                    StaticPageID = i,
                    Content = "Some content" + i,
                    Title = "Some Title" + i,
                    url = "some url" + i
                });
            }
        }

        

        public List<BlogEntry> GetAll()
        {
            return Blogs;
        }

        public void DeleteEntry(int id)
        {
            foreach (var blogEntry in Blogs.Where(blogEntry => blogEntry.BlogID == id))
            {
                Blogs.Remove(blogEntry);
                break;
            }
        }

        public BlogEntry GetBlog(int id)
        {
            foreach (var blog in Blogs)
            {
                if (blog.BlogID == id)
                {
                    return blog;
                }
            }

            return null;

        }

        public void CreateStaticPage(StaticEntry staticEntry)
        {
            Static.Add(staticEntry);
        }

        public void EditEntry(BlogEntry blogEntry)
        {
            GetBlog(1);
            blogEntry.PostContents = "edit";

        }

        public void CreateEntry(BlogEntry blogEntry)
        {
            Blogs.Add(blogEntry);
        }

        public List<StaticEntry> GetAllStatic()
        {
            return Static;
        }

        public void DeleteStaticEntry(int id)
        {
            foreach (var staticEntry in Static.Where(staticEntry => staticEntry.StaticPageID == id))
            {
                Static.Remove(staticEntry);
                break;
            }
        }

        public void EditStaticEntry(StaticEntry staticEntry)
        {
            GetStatic(2);
            staticEntry.Content = "edit";
        }

        public StaticEntry GetStatic(int id)
        {
            foreach (var staticPage in Static)
            {
                if (staticPage.StaticPageID == id)
                {
                    return staticPage;
                }
            }

            return null;
        }
    }
}
