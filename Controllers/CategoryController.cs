using BlogApp24012022.Models;
using BlogApp24012022.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp24012022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        //data fields
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        

        #region without route get all categories
        [HttpGet]
        
        public async Task<ActionResult<List<Category>>> GetCategoriesOfAll()
        {          
               return await _categoryRepository.GetCategoriesOfAll();           
        }
        #endregion

        

        #region get all categories
        [HttpGet]
        [Authorize]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [Route("GetCategoriesAll")]
        public async Task<IActionResult> GetCategoriesAll()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region add a category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryID = await _categoryRepository.AddCategory(category);
                    if (categoryID > 0)
                    {
                        return Ok(categoryID);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region get all categories 
       // [HttpGet]
        //[Authorize]

        #endregion

    }
}
