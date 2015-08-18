using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DATA.Interfaces;
using Blog.MODELS;

namespace Blog.DATA
{
    public class CategoryRepo : ICategoryRepo
    {
        public List<Category> GetAllCategories()
        {
            var category = new List<Category>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetAllCategories", cn) { CommandType = CommandType.StoredProcedure };

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var cat = new Category
                        {
                            CategoryId = dr.GetInt32(0),
                            CategoryName = dr.GetString(1)
                        };
                        category.Add(cat);
                    }
                }
            }
            return category;
        }

        public Category GetCategoryById(int catId)
        {
            var category = new Category();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetCategoryById", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@CategoryId", catId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var cat = new Category
                        {
                            CategoryId = dr.GetInt32(0),
                            CategoryName = dr.GetString(1)
                        };
                        return cat;
                    }
                }
            }
            return null;
        }

        public void AddCategory(Category category)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddCategory", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditCategory(Category category)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("EditCategory", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(Category category)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("DeleteCategory", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
