using Identity.Application.Dto;
using Refit;

namespace Identity.Abstraction.RemoteCall
{
    public interface IUserRemoteCall
    {
        [Get("/api/user")]
        public Task<IList<UserDto>> GetUsers();

        [Get("/api/user/{id}")]
        public Task<IList<UserDto>> GetUserById(Guid id);

        [Post("/api/user/login")]
        public Task<UserDto> Login([Body] LoginDto loginDto);
    }
}
