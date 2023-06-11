using Data.UnitOfWork;
using Identity.Application.Dto;
using Identity.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Application.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IList<UserDto>> GetUsers()
        {
            var users = await this._unitOfWork.GetRepository<User>().GetAll();

            return users.Select(e => UserDto.Map(e)).ToList();
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await this._unitOfWork.GetRepository<User>().GetById(id);

            if (user == null)
            {
                throw new Exception("Incorrect username or password");
            }

            return UserDto.Map(user);
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = ((await this._unitOfWork.GetRepository<User>().Find(user =>
                user.Email == loginDto.Email && user.Password == loginDto.Password)).FirstOrDefault());

            if (user == null)
            {
                throw new Exception("Incorrect username or password");
            }

            return UserDto.Map(user);
        }

        public string GenerateToken(UserDto user)
        {
            var secret = this._configuration["JWT:Secret"]?.ToString();
            var issuer = this._configuration["JWT:Issuer"]?.ToString();
            var audience = this._configuration["JWT:Audience"]?.ToString();

            if (secret == null || issuer == null || audience == null)
            {
                throw new Exception("Incorrect JWT configigration");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var token = new JwtSecurityToken(issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
