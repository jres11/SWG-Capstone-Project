using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.MODELS;

namespace Blog.DATA
{
    public interface IBlogRepo
    {
        List<BlogEntry> GetAll();
        void DeleteEntry(int id);
        void CreateEntry(BlogEntry blogEntry);
        void EditEntry(BlogEntry blogEntry);
        void CreateStaticPage(StaticEntry staticEntry);
        StaticEntry GetStatic(int id);
        BlogEntry GetBlog(int id);
        List<StaticEntry> GetAllStatic();
        void DeleteStaticEntry(int id);
        void EditStaticEntry(StaticEntry staticEntry);
    }

    public class BlogRepo : IBlogRepo
    {
        public List<BlogEntry> GetAll()
        {
            var blogEntries = new List<BlogEntry>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("GetBlogEntries", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var temp = new BlogEntry();
                        temp.BlogID = dr.GetInt32(0);
                        temp.PostContents = dr.GetString(1);
                        temp.UserID = dr.GetString(2);
                        temp.DateOfPost = dr.GetDateTime(3);
                        temp.StartDate = dr["StartDate"] is DBNull ? DateTime.Now : dr.GetDateTime(4);
                        temp.EndDate = dr["StartDate"] is DBNull ? DateTime.Now.AddYears(100) : dr.GetDateTime(5);
                        temp.StatusID = dr.GetInt32(6);
                        temp.Title = dr.GetString(7);
                        temp.UserName = dr.GetString(8);
                        blogEntries.Add(temp);
                    }
                }
            }
            return blogEntries;
        }

        public void DeleteEntry(int id)
        {
            
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("DeleteBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogPostID", id);
                

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateEntry(BlogEntry blogEntry)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("CreateBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostContents", blogEntry.PostContents);
                cmd.Parameters.AddWithValue("@UserID", blogEntry.UserID);
                cmd.Parameters.AddWithValue("@DateOfPost", blogEntry.DateOfPost);
                if (blogEntry.StartDate == null)
                {
                    cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StartDate", blogEntry.StartDate); 
                }
                if (blogEntry.StartDate == null)
                {
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EndDate", blogEntry.StartDate);
                }
                //cmd.Parameters.AddWithValue("@StartDate", blogEntry.StartDate);
                //cmd.Parameters.AddWithValue("@EndDate", blogEntry.EndDate);
                cmd.Parameters.AddWithValue("@StatusID", blogEntry.StatusID);
                cmd.Parameters.AddWithValue("@Title", blogEntry.Title);
                //cmd.Parameters.AddWithValue("@CategoryName", blogEntry.CategoryName);
                // DO NOT UNCOMMENT UNTIL SPROC IS UPDATED

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditEntry(BlogEntry blogEntry)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("EditBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogPostID", blogEntry.BlogID);
                cmd.Parameters.AddWithValue("@PostContents", blogEntry.PostContents);
                cmd.Parameters.AddWithValue("@UserID", blogEntry.UserID);
                cmd.Parameters.AddWithValue("@DateOfPost", blogEntry.DateOfPost);
                cmd.Parameters.AddWithValue("@StartDate", blogEntry.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", blogEntry.EndDate);
                cmd.Parameters.AddWithValue("@Title", blogEntry.Title);
                cmd.Parameters.AddWithValue("@StatusID", blogEntry.StatusID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateStaticPage(StaticEntry staticEntry)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("CreateStaticEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Content", staticEntry.Content);
                cmd.Parameters.AddWithValue("@Title", staticEntry.Title);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BlogEntry GetBlog(int id)
        {
            var temp = new BlogEntry();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                
                var cmd = new SqlCommand("GetBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogPostID", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        temp.BlogID = dr.GetInt32(0);
                        temp.PostContents = dr.GetString(1);
                        temp.UserID = dr.GetString(2);
                        temp.DateOfPost = dr.GetDateTime(3);
                        temp.StartDate = dr["StartDate"] is DBNull ? DateTime.Now : dr.GetDateTime(4);
                        temp.EndDate = dr["StartDate"] is DBNull ? DateTime.Now.AddYears(100) : dr.GetDateTime(5);
                        temp.StatusID = dr.GetInt32(6);
                        temp.Title = dr.GetString(7);
                        temp.UserName = dr.GetString(8);
                        return temp;
                    }
                }
            }
            return temp;
        }

        public StaticEntry GetStatic(int id)
        {
            var temp = new StaticEntry();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("GetStaticEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaticPageID", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        temp.StaticPageID = dr.GetInt32(0);
                        temp.Title = dr.GetString(1);
                        temp.Content = dr.GetString(2);
                        return temp;
                    }
                }
            }
            return temp;
        }

        public List<StaticEntry> GetAllStatic()
        {
            var staticEntries = new List<StaticEntry>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("GetStaticEntries", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var temp = new StaticEntry();
                        temp.StaticPageID = dr.GetInt32(0);
                        temp.Content = dr.GetString(1);
                        temp.Title = dr.GetString(2);
                        staticEntries.Add(temp);
                    }
                }
            }
            return staticEntries;
        }

        public void DeleteStaticEntry(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("DeleteStaticEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaticPageID", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditStaticEntry(StaticEntry staticEntry)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand("EditStaticEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaticPageID", staticEntry.StaticPageID);
                cmd.Parameters.AddWithValue("@Title", staticEntry.Title);
                cmd.Parameters.AddWithValue("@Content", staticEntry.Content);
                

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }

}
