using Data.Entity;

namespace Post.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Guid OwnerId { get; set; }

        public virtual CommentOwner Owner { get; set; }

        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
