using Bff.Mobile.Api.Services;
using Identity.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Mobile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            this._loginService = loginService;
        }

        [HttpPost]
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            return await this._loginService.Login(loginDto);
        }
    }
}
