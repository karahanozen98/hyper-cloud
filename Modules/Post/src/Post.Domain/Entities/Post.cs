using Data.Entity;

namespace Post.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; } 

        public byte[] File { get; set; }

        public bool IsPublic { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public Guid OwnerId { get; set; }

        public PostOwner Owner { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
