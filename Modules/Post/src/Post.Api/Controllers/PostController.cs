using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Dto;
using Post.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return await this._postService.GetPostsById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task Post([FromBody] CreatePostDto createPostDto)
        {
            await this._postService.CreatePost(createPostDto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await this._postService.DeletePost(id);
        }
    }
}
