using Data.UnitOfWork;
using Identity.Application.Dto;
using Identity.Domain.Entities;

namespace Identity.Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
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
    }
}
