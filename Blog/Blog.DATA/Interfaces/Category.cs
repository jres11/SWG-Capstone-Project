using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.MODELS;

namespace Blog.DATA.Interfaces
{
    public interface ICategoryRepo
    {
        List<Category> GetAllCategories();

        Category GetCategoryById(int catId);

        void AddCategory(Category category);

        void EditCategory(Category category);

        void DeleteCategory(Category category);

    }
}
