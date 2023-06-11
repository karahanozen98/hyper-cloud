using Post.Application.Dto;
using Refit;

namespace Post.Abstraction.RemoteCall
{
    public interface IPostRemoteCall
    {
        [Get("/api/post")]
        public Task<IList<PostDto>> GetPosts();

        [Get("/api/post/{id}")]
        public Task<PostDto> GetPostById(Guid id);

        [Post("/api/post")]
        public Task CreatePost(CreatePostDto createPostDto);

        [Delete("/api/post/{id}")]
        public Task DeletePost(Guid id);
    }
}
