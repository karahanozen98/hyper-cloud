using Identity.Application.Dto;
using Identity.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await this._userService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UserDto>> GetUserById([FromRoute] Guid id)
        {
            return await this._userService.GetUsers();
        }

        [HttpPost]
        public async Task<IEnumerable<UserDto>> Create([FromBody] UserDto userDto)
        {
            return await this._userService.GetUsers();
        }

        [HttpPost("/login")]
        public async Task<UserDto> Login([FromBody] LoginDto loginDto)
        {
            return await this._userService.Login(loginDto);
        }
    }
}
