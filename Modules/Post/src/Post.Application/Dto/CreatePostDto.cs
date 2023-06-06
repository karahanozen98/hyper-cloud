namespace Post.Application.Dto
{
    public class CreatePostDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string File { get; set; }

        public bool IsPublic { get; set; }

        public string Thumbnail { get; set; }

        public PostOwnerDto Owner { get; set; }

        public List<string> Tags { get; set; }
    }

    public class PostOwnerDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
