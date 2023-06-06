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

        // GET: api/<PostController>
        [HttpGet]
        public async Task<IList<PostDto>> Get()
        {
            return await this._postService.GetPosts();
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
