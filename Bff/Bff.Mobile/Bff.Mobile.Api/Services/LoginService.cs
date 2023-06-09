using Identity.Abstraction.RemoteCall;
using Identity.Application.Dto;

namespace Bff.Mobile.Api.Services
{
    public class LoginService
    {
        private readonly IUserRemoteCall _userRemoteCall;

        public LoginService(IUserRemoteCall userRemoteCall)
        {
            this._userRemoteCall = userRemoteCall;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            return await this._userRemoteCall.Login(loginDto);
        }
    }
}
