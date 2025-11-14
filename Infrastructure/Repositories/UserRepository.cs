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

        public async Task<bool> AddAsync(User entity)
        {
            _log.LogInfo("UserRepository.AddAsync -  Init");
            try
            {
                if (entity == null)
                {
                    throw new InfrastructureException("User entity cannot be null.", _log);
                }

                await _context.Users.AddAsync(entity);

                var res = await _context.SaveChangesAsync() > 0;

                _log.LogInfo("UserRepository.AddAsync -  finish succesfull");

                return res;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.AddAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving bike from database.", _log, ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid UserId)
        {
            _log.LogInfo("UserRepository.DeleteAsync - init");
            try
            {
                if (UserId == Guid.Empty)
                {
                    throw new InfrastructureException("UserId cannot be null.", _log);
                }

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserId);

                _context.Users.Remove(user);

                var res = await _context.SaveChangesAsync() > 0;

                _log.LogInfo("UserRepository.DeleteAsync -  finish succesfull");

                return res;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.DeleteAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving bike from database.", _log, ex);
            }
        }

        public async Task<List<User>> GetAllAsync(int page = 1, int pageSize = 10, UserRole? role = null)
        {
            _log.LogInfo("UserRepository.GetAllAsync - init");

            try
            {
                var query = _context.Users.AsNoTracking().AsQueryable();

                if (role.HasValue)
                {
                    query = query.Where(u => u.Role == role);
                }

                var users = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                _log.LogInfo("UserRepository.GetAllAsync - finish successful");
                return users;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.GetAllAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving users from database.", _log, ex);
            }
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            _log.LogInfo("UserRepository.GetByIdAsync - init");
            try
            {
                var user = _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

                _log.LogInfo("UserRepository.GetByIdAsync -  finish succesfull");

                return user;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.GetByIdAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving bike from database.", _log, ex);
            }
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            _log.LogInfo("UserRepository.UpdateAsync - init");
            try
            {
                if (entity == null)
                {
                    throw new InfrastructureException("User entity cannot be null.", _log);
                }

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == entity.UserId);

                user.Name = entity.Name;
                user.LastName = entity.LastName;
                user.Document = entity.Document;
                user.Phone = entity.Phone;
                user.Address = entity.Address;

                var res = await _context.SaveChangesAsync() > 0;

                _log.LogInfo("UserRepository.UpdateAsync -  finish succesfull");

                return res;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.GetByIdAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving bike from database.", _log, ex);
            }
        }

        public async Task<User?> GetByCredentialsAsync(string email, string password)
        {
            _log.LogInfo("UserRepository.GetByCredentialsAsync - init");
            try
            {
                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);

                _log.LogInfo("UserRepository.GetByCredentialsAsync - finish successful");
                return user;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.GetByCredentialsAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving user from database.", _log, ex);
            }
        }

        public async Task<bool> ChangePassword(Guid UserId, string newPassword)
        {
            _log.LogInfo("ChangePassword.ChangePassword - Init");
            try
            {
                if (string.IsNullOrEmpty(newPassword))
                {
                    throw new InfrastructureException("New password cannot be null or empty.", _log);
                }

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserId);

                if (user == null)
                {
                    throw new InfrastructureException("User information not found.", _log);
                }

                if (newPassword.Equals(user.PasswordHash))
                {
                    throw new InfrastructureException("The new password must be different from the current password.", _log);
                }

                user.ChangePassword(newPassword);

                var res = await _context.SaveChangesAsync() > 0;

                _log.LogInfo("UserRepository.ChangePassword - finish succesful");

                return res;

            }
            catch (InfrastructureException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _log.LogError($"UserRepository.ChangePassword - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving user from database.", _log, ex);
            }
        }
    }
}
