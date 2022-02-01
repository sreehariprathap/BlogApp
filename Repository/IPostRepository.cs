using BlogApp24012022.Models;
using BlogApp24012022.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp24012022.Repository
{
    public interface IPostRepository
    {
        //get all categories
        //Task<List<Category>> GetAllCategories();

        //add a category
        //Task<int> AddCategory(Category category);



        //asynchronous operation
        //get all categories

        //Task<List<Category>> GetAllCategories();  //--1


        //Get  posts
        //Task<List<Post>> GetPosts();

        //add a post
        Task<int> AddPost(Post post);

        //update post
        Task UpdatePost(Post post);

        //get all posts  -- viewmodel  --hide properties that are suppose to not show
        //reduce 
        //
        Task<List<PostViewModel>> GetAllPosts();


        //get post by id --viewmodel
        Task<PostViewModel> GetThePost(int? postId);
        Task<int> DeletePostById(int? id);
        //Task DeletePost(int? postId);
    }
}
