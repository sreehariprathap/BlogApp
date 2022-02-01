using BlogApp24012022.Models;
using BlogApp24012022.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp24012022.Repository
{
    public class PostRepository : IPostRepository
    {
        //data fields
        private readonly DemoBlogDBContext _contextOne;


        //constructor based dependency injection
        public PostRepository(DemoBlogDBContext contextOne)
        {
            _contextOne = contextOne;
        }
       
        /*
        #region get all posts
        public async Task<List<Post>> GetPosts()
        {
            if(_contextOne!= null)
            {
                return await _contextOne.Post.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        */

        #region add a post
        public async Task<int> AddPost(Post post)
        {
            if(_contextOne != null)
            {
                await _contextOne.Post.AddAsync(post);
                await _contextOne.SaveChangesAsync();
                return post.Postid;

            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region update a post
        public async Task UpdatePost(Post post)
        {
            if(_contextOne != null)
            {
                _contextOne.Entry(post).State = EntityState.Modified;
                _contextOne.Post.Update(post);
                await _contextOne.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion


        #region get all the posts 2
        public async Task<List<PostViewModel>> GetAllPosts()
        {
            //ILNQ
            //join post and category
            if(_contextOne != null)
            {
                return await(from p in _contextOne.Post
                             from c in _contextOne.Category
                             where p.Categoryid == c.Id
                             select new PostViewModel
                             {
                                 Postid = p.Postid,
                                 Title = p.Title,
                                 Createddate = p.Createddate,
                                 Description = p.Description,
                                 Categoryid = p.Categoryid,
                                 CategoryName = c.Name
                             }).ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        
        #region get the post by id
        public async Task<PostViewModel> GetThePost(int? postId)
        {
            if (_contextOne != null)
            {
                return await (from p in _contextOne.Post
                              from c in _contextOne.Category
                              where p.Postid == postId
                              select new PostViewModel
                              {
                                  Postid = p.Postid,
                                  Title = p.Title,
                                  Createddate = p.Createddate,
                                  Description = p.Description,
                                  Categoryid = p.Categoryid,
                                  CategoryName = c.Name
                              }).FirstOrDefaultAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region delete post 

        public async Task<int> DeletePostById(int? id)
        {
            //declare result
            int result = 0;
            if(_contextOne != null)
            {
                var post = await _contextOne.Post.FirstOrDefaultAsync(po => po.Postid == id);
                if(post != null)
                {
                    //perform delete
                    _contextOne.Post.Remove(post);
                    result = await _contextOne.SaveChangesAsync(); //commit

                }
                return result;
            }
            return result;
        }
        #endregion





    }
}
