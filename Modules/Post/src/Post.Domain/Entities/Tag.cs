using Data.Entity;

namespace Post.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
