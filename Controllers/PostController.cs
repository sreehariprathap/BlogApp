using BlogApp24012022.Models;
using BlogApp24012022.Repository;
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
    public class PostController : ControllerBase
    {

        //data fields
        private readonly IPostRepository _postRepository;

        //constructor injection

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /*
        #region get all posts
        [HttpGet]
        [Route("GetPosts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }
        #endregion
        */

        #region get all posts 2
        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = await _postRepository.GetAllPosts();
                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        
        #region get a post by id
        [HttpGet]
        [Route("GetThePost")]
        public async Task<IActionResult> GetThePost(int? postId)
        {
            
            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                var postOne = await _postRepository.GetThePost(postId);
                if (postOne == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        
        #region add a post
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postID = await _postRepository.AddPost(post);
                    if (postID > 0)
                    {
                        return Ok(postID);
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


        //#region get a post by id
        //[HttpDelete]
        //[Route("DeleteThePost")]
        //public async Task<IActionResult> DeletePost(int? postId)
        //{

        //    if (postId == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {

        //        var postOne = await _postRepository.DeletePost(postId);
        //        if (postOne == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion


        #region update a post
        [HttpDelete("{id}")]               //https://localhost:44346/api/Blog/
        public async Task<IActionResult> DeletePostById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _postRepository.DeletePostById(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
