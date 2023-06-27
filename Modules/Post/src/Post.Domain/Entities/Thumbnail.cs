using Data.Entity;

namespace Post.Domain.Entities
{
    public class Thumbnail : BaseEntity
    {
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }

        public string Data { get; set; }    
    }
}
