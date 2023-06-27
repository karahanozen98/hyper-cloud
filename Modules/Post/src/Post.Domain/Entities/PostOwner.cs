using Data.Entity;

namespace Post.Domain.Entities
{
    public class PostOwner : BaseEntity
    {
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
