using BlogApp24012022.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp24012022.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DemoBlogDBContext _contextTwo;

        //constructor based dependency injection
        public CategoryRepository(DemoBlogDBContext contextTwo)
        {
            _contextTwo = contextTwo;
        }

        #region get all categories
        public async Task<List<Category>> GetAllCategories()
        {
            if (_contextTwo != null)
            {
                //performing lampda expression  for many post scenario
                return await _contextTwo.Category.Include(p => p.Post).ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region add a category
        public async Task<int> AddCategory(Category category)
        {
            if (_contextTwo != null)
            {
                await _contextTwo.Category.AddAsync(category);
                await _contextTwo.SaveChangesAsync();
                return category.Id;
            }
            return 0;
            //throw new NotImplementedException();
        }

        #endregion

        #region update a Category
        public async Task UpdateCategory(Category category)
        {
            if (_contextTwo != null)
            {
                _contextTwo.Entry(category).State = EntityState.Modified;
                _contextTwo.Category.Update(category);
                await _contextTwo.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region get all the categories
        
        public async Task<List<Category>> GetCategoriesOfAll()
        {
            if (_contextTwo != null)
            {
                
                return await _contextTwo.Category.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
