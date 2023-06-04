using Data.Entity;

namespace Post.Domain.Entities
{
    public class Thumbnail : BaseEntity
    {
        public Guid PostId { get; set; }

        public Post Post { get; set; }

        public byte[] Data { get; set; }    
    }
}
