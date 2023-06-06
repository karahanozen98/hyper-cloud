namespace Post.Application.Dto
{
    public class PostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string File { get; set; }

        public bool IsPublic { get; set; }

        public byte[] Thumbnail { get; set; }

        public PostOwnerDto Owner { get; set; }

        public List<string> Tags { get; set; }
    }
}
