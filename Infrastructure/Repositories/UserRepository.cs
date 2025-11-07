namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SintronicoDBContext _context;
        private readonly ILogService<LogService> _log;

        public UserRepository(SintronicoDBContext context, ILogService<LogService> log)
        {
            _context = context;
            _log = log;
        }

        public Task<bool> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync(int page = 1, int pageSize = 10, UserRole? role = null)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            return user;
        }

        public Task<List<User>> GetPagedAsync(int page, int pageSize, UserRole role)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
