using Identity.Abstraction.RemoteCall;
using Identity.Application.Dto;

namespace Bff.Mobile.Api.Services
{
    public class LoginService
    {
        private readonly IUserRemoteCall _userRemoteCall;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IUserRemoteCall userRemoteCall, IHttpContextAccessor httpContextAccessor)
        {
            this._userRemoteCall = userRemoteCall;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var response = await this._userRemoteCall.Login(loginDto);

            if(!response.IsSuccessStatusCode)
            {
                throw response.Error;
            }

            var token = response.Headers.FirstOrDefault(x => x.Key == "Set-Cookie").Value.FirstOrDefault();

            if(token == null)
            {
                throw new Exception("Authorization token is empty");
            }

            this._httpContextAccessor?.HttpContext?.Response.Headers.Append("Set-Cookie", token);

            return response.Content;
        }
    }
}
