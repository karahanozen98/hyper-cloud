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

        public static UserDto Map(User user)
        {
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.FirstName = user.FirstName;
            dto.MiddleName = user.MiddleName;
            dto.LastName = user.LastName;
            dto.Email = user.Email;
            dto.Role = user.Role;

            return dto;
        }
    }
}

