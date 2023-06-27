using Data.Entity;

namespace Post.Domain.Entities
{
    public class CommentOwner : BaseEntity
    {
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
