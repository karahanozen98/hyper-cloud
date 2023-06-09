using Post.Abstraction.RemoteCall;
using Post.Application.Dto;

namespace Bff.Mobile.Api.Services
{
    public class PostService
    {
        private readonly IPostRemoteCall _postRemoteCall;

        public PostService(Post.Abstraction.RemoteCall.IPostRemoteCall postRemoteCall)
        {
            this._postRemoteCall = postRemoteCall;
        }

        public async Task<IList<PostDto>> GetPosts()
        {
            return await this._postRemoteCall.GetPosts();
        }

        public async Task<PostDto> GetPostById(Guid id)
        {
            return await this._postRemoteCall.GetPostById(id);
        }

        public async Task CreatePost(CreatePostDto dto)
        {
            await this._postRemoteCall.CreatePost(dto);
        }
    }
}
