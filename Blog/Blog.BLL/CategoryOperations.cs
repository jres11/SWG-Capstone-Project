using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DATA;
using Blog.DATA.Interfaces;
using Blog.MODELS;

namespace Blog.BLL
{
    public class CategoryOperations
    {
        private ICategoryRepo _categoryRepo { get; set; }

        public CategoryOperations(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public CategoryOperations()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public Category GetCategoryById(int catId)
        {
            return _categoryRepo.GetCategoryById(catId);
        }

        public void AddCategory(Category category)
        {
            _categoryRepo.AddCategory(category);
        }

        public void EditCategory(Category category)
        {
            _categoryRepo.EditCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepo.DeleteCategory(category);
        }
    }
}
