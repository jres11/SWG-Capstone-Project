using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DATA;
using Blog.MODELS;

namespace Blog.BLL
{
    public class BlogOperations
    {
        private IBlogRepo _blogRepo { get; set; }

        public BlogOperations(IBlogRepo blogRepo)
        {
            _blogRepo = blogRepo;
        }
        public BlogOperations()
        {
            _blogRepo = new BlogRepo();
        }

        public List<BlogEntry> GetAllBlogEntries()
        {
            return _blogRepo.GetAll();
        }

        public void DeleteBlogEntry(int id)
        {
            _blogRepo.DeleteEntry(id);
        }

        public void EditBlogEntry(BlogEntry blogEntry)
        {
            _blogRepo.EditEntry(blogEntry);
        }

        public void CreateBlogEntry(BlogEntry blogEntry)
        {
            blogEntry.DateOfPost = DateTime.Now;
            blogEntry.StatusID = 1;
            _blogRepo.CreateEntry(blogEntry);
        }

        public void CreateStaticEntry(StaticEntry staticEntry)
        {
            _blogRepo.CreateStaticPage(staticEntry);
        }

        public BlogEntry GetBlogEntry(int id)
        {
            return _blogRepo.GetBlog(id);
        }

        public StaticEntry GetStaticEntry(int id)
        {
            return _blogRepo.GetStatic(id);
        }

        public List<StaticEntry> GetStaticEntries()
        {
            return _blogRepo.GetAllStatic();
        }

        public void DeleteStaticEntry(int id)
        {
            _blogRepo.DeleteStaticEntry(id);
        }

        public void EditStaticEntry(StaticEntry staticEntry)
        {
            _blogRepo.EditStaticEntry(staticEntry);
        }
    }
}
