using Data.Entity;

namespace Post.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
