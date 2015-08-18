using System;
using System.Reflection;
using Blog.BLL;
using Blog.MODELS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blog.TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAllBlog()
        {
            var operations = new BlogOperations(new MockRepo());

            Assert.AreEqual(5, operations.GetAllBlogEntries().Count);
        }

        [TestMethod]
        public void TestCreateBlog()
        {
            var operations = new BlogOperations(new MockRepo());
            var blogEntry = new BlogEntry();
            operations.CreateBlogEntry(blogEntry);
            Assert.AreEqual(6, operations.GetAllBlogEntries().Count);
        }

        [TestMethod]
        public void TestDeleteBlog()
        {
            var operations = new BlogOperations(new MockRepo());
            operations.DeleteBlogEntry(2);
            Assert.AreEqual(4, operations.GetAllBlogEntries().Count);
        }

        [TestMethod]
        public void TestGetBlog()
        {
            var operations = new BlogOperations(new MockRepo());
            var expected = new BlogEntry()
            {
                BlogID = 6,
                DateOfPost = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(2),
                StartDate = DateTime.Now.Date,
                Title = "Fake Title" + 6,
                PostContents = "Test Post" + 6,
                StatusID = 1,
                UserID = "19faea31-fb63-4d55-b661-6884255d4d53"
            };
            operations.CreateBlogEntry(expected);
            Assert.AreEqual(expected, operations.GetBlogEntry(6));
        }

        [TestMethod]
        public void TestEditEntry()
        {
            var operations = new BlogOperations(new MockRepo());
            var blogEntry = operations.GetBlogEntry(1);
            blogEntry.BlogID = 1;
            blogEntry.PostContents = "edit";
            operations.EditBlogEntry(blogEntry);
            Assert.AreEqual("edit", operations.GetBlogEntry(1).PostContents);
        }

        [TestMethod]
        public void TestCreateStatic()
        {
            var operations = new BlogOperations(new MockRepo());
            var staticEntry = new StaticEntry();
            operations.CreateStaticEntry(staticEntry);
            Assert.AreEqual(4, operations.GetStaticEntries().Count);
        }

        [TestMethod]
        public void TestGetStatic()
        {
            var operations = new BlogOperations(new MockRepo());
            var expected = new StaticEntry()
            {
                StaticPageID = 4,
                Content = "Fake Content" + 4,
                Title = "Fake Title" + 4,
                url = "/Fakeurl"
            };
            
            operations.CreateStaticEntry(expected);
            Assert.AreEqual(expected, operations.GetStaticEntry(4));
        }

        [TestMethod]
        public void TestDeleteStatic()
        {
            var operations = new BlogOperations(new MockRepo());
            operations.DeleteStaticEntry(2);
            Assert.AreEqual(2, operations.GetStaticEntries().Count);
        }

        [TestMethod]
        public void TestEditStatic()
        {
            var operations = new BlogOperations(new MockRepo());
            var staticEntry = operations.GetStaticEntry(2);
            staticEntry.StaticPageID = 2;
            staticEntry.Content = "edit";
            operations.EditStaticEntry(staticEntry);
            Assert.AreEqual("edit", operations.GetStaticEntry(2).Content);
        }
    }
}
