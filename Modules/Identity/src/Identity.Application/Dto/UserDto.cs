using Identity.Common.Enums;
using Identity.Domain.Entities;

namespace Identity.Application.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public UserDto(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.MiddleName = user.MiddleName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.Role = user.Role;
        }
    }

    public static class UserExtension
    {
        public static UserDto Map(this User user)
        {
            return new UserDto(user);
        }
    }
}

