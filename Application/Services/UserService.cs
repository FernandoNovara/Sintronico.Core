using Application.Interfaces;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<PagedResult<UserDto>> GetPagedAsync(int page, int pageSize, UserRole role)
        {
            if (page <= 0 || pageSize <= 0)
                throw new ApplicationException("Invalid parameters.");

            var user = await _userRepository.GetAllAsync();

            user = user.Where(b => b.Role == role).ToList();

            var total = user.Count;
            var items = user.Skip((page - 1) * pageSize).Take(pageSize).Select(UserMapper.ToDto).ToList();

            return new PagedResult<UserDto>
            {
                page = page,
                pageSize = pageSize,
                total = total,
                items = items
            };
        }
    }
}
