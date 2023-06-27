using Data.Entity;

namespace Post.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; } 

        public string File { get; set; }

        public bool IsPublic { get; set; }

        public virtual Thumbnail Thumbnail { get; set; }

        public Guid OwnerId { get; set; }

        public virtual PostOwner Owner { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Tag> Tags { get; set; }
    }
}
