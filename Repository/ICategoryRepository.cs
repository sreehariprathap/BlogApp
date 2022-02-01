using BlogApp24012022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp24012022.Repository
{
    public interface ICategoryRepository
    {
        //get all categories
        Task<List<Category>> GetAllCategories();

        Task<List<Category>> GetCategoriesOfAll();

        //add a category
        Task<int> AddCategory(Category category);

        //update Category
        Task UpdateCategory(Category category);
    }
}
