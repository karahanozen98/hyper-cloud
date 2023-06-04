using Data.Entity;
using Identity.Common.Enums;

namespace Identity.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}

