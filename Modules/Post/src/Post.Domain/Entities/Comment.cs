using Data.Entity;

namespace Post.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Guid OwnerId { get; set; }

        public CommentOwner Owner { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}
