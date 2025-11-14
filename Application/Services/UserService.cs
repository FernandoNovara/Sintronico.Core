namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<UserDto>> GetPagedAsync(int page, int pageSize, UserRole? role)
        {
            if (page <= 0 || pageSize <= 0)
                throw new ApplicationException("Invalid parameters.");

            var user = await _userRepository.GetAllAsync(page, pageSize, role);

            var total = user.Count;
            var items = user.Select(UserMapper.ToDto).ToList();

            return new PagedResult<UserDto>
            {
                page = page,
                pageSize = pageSize,
                total = total,
                items = items
            };
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Invalid parameters.");
            }

            var res = await _userRepository.GetByIdAsync(id);

            if (res == null)
            {
                throw new ApplicationException("User not found.");
            }

            return UserMapper.ToDto(res);
        }

        public async Task<bool> CreateAsync(User entity)
        {
            entity.UserId = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            var res = await _userRepository.AddAsync(entity);
            return res;
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            if (entity.UserId == Guid.Empty)
            {
                throw new ApplicationException("Invalid parameters.");
            }

            var res = await _userRepository.UpdateAsync(entity);

            return res;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Invalid parameters.");
            }

            var res = await _userRepository.DeleteAsync(id);
            return res;
        }

        public async Task<UserDto> Login(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
                throw new ApplicationException("Invalid parameters.");
            var res = await _userRepository.GetByCredentialsAsync(user, password);

            if (res == null)
            {
                throw new ApplicationException("Invalid username or password.");
            }

            return UserMapper.ToDto(res);
        }

        public async Task<bool> ChangePassword(Guid UserId, string newPassword)
        {
            if (UserId == Guid.Empty || string.IsNullOrWhiteSpace(newPassword))
                throw new ApplicationException("Invalid parameters.");

            var res = await _userRepository.ChangePassword(UserId, newPassword);

            return res;
        }
    }
}
