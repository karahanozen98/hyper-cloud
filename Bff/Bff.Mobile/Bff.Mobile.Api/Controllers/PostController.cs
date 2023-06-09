using Bff.Mobile.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Dto;

namespace Bff.Mobile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            this._postService = postService;
        }

        [HttpGet]
        public async Task<IList<PostDto>> Get()
        {
            return await this._postService.GetPosts();
        }

        [HttpGet("{id}")]
        public async Task<PostDto> GetPostById([FromRoute] Guid id)
        {
            return await this._postService.GetPostById(id);
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task Post([FromBody] CreatePostDto createPostDto)
        {
            await this._postService.CreatePost(createPostDto);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
