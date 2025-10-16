namespace Application.DTOs
{
    public record UserDto
        (
            Guid UserId,
            string Name,
            string LastName,
            string Email,
            string PasswordHash,
            string Document,
            string Phone,
            string Address,
            UserRole Role,
            DateTime CreatedAt
        );
}