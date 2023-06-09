

using Data.Repository;
using Data.UnitOfWork;
using Post.Application.Dto;
using Post.Domain.Entities;

namespace Post.Application.Services
{
    public class PostService
    {
        private readonly IRepository<Domain.Entities.Post> _postRepository;
        private readonly IRepository<PostOwner> _postOwnerRespository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this._postRepository = unitOfWork.GetRepository<Domain.Entities.Post>();
            this._postOwnerRespository = unitOfWork.GetRepository<PostOwner>();
            this._unitOfWork = unitOfWork;
        }

        public async Task<IList<PostDto>> GetPosts()
        {
            return (await this._postRepository.GetAll()).Select(post => new PostDto
            {
                Id = post.Id,
                Description = post.Description,
                Content = post.Content,
                File = post.File,
                IsPublic = post.IsPublic,
                Owner = new PostOwnerDto { Id = post.Owner.Id, FirstName = post.Owner.FirstName, LastName = post.Owner.LastName },
                Title = post.Title
            }).ToList();
        }

        public async Task<PostDto> GetPostsById(Guid id)
        {
            var post = (await this._postRepository.GetById(id));
            var postDto =  new PostDto
            {
                Id = post.Id,
                Description = post.Description,
                Content = post.Content,
                File = post.File,
                IsPublic = post.IsPublic,
                Owner = null,
                Title = post.Title
            };

            return postDto;
        }

        public async Task CreatePost(CreatePostDto createPostDto)
        {
            var postOwner = await this._postOwnerRespository.GetById(createPostDto.Owner.Id);

            if (postOwner == null)
            {
                postOwner = new PostOwner
                {
                    Id = createPostDto.Owner.Id,
                    FirstName = createPostDto.Owner.FirstName,
                    LastName = createPostDto.Owner.LastName,
                    MiddleName = createPostDto.Owner.MiddleName,
                    Email = createPostDto.Owner.Email,
                };

                this._postOwnerRespository.Create(postOwner);
                this._unitOfWork.Save();
            }

            var post = new Domain.Entities.Post
            {
                Id = new Guid(),
                Title = createPostDto.Title,
                Content = createPostDto.Content,
                Tags = new List<Tag>(),
                Comments = new List<Comment>(),
                Description = createPostDto.Description,
                File = createPostDto.File,
                OwnerId = postOwner.Id,
                Thumbnail = new Thumbnail { Data = createPostDto.Thumbnail },
            };

            await this._postRepository.Create(post);
        }
    }
}
