namespace Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user) =>
            new(
                user.UserId,
                user.Name,
                user.LastName,
                user.Email,
                user.PasswordHash,
                user.Document,
                user.Phone,
                user.Address,
                user.Role,
                user.CreatedAt
            );

        public static User ToDomain(UserDto dto) =>
            new(
                dto.UserId,
                dto.Name,
                dto.LastName,
                dto.Email,
                dto.PasswordHash,
                dto.Role,
                dto.CreatedAt
            )
            {
                Document = dto.Document,
                Phone = dto.Phone,
                Address = dto.Address
            };
    }
}
