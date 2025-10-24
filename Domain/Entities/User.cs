using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        /// <summary>
        /// identifier for the user
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// name of the user
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; private set; } = string.Empty;
        /// <summary>
        /// password hash of the user
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;
        /// <summary>
        /// document of the user
        /// </summary>
        public string Document { get; set; } = string.Empty;
        /// <summary>
        /// phone number of the user
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// address of the user
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// role of the user
        /// </summary>
        public UserRole Role { get; set; } = UserRole.Client;
        /// <summary>
        /// Date and time when the user was created
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public User() { }

        public User(Guid userId, string name, string lastName, string email, string passwordHash, UserRole role, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required");
            if (!email.Contains("@")) throw new ArgumentException("Invalid email");

            UserId = userId;
            Name = name;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            CreatedAt = createdAt;
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }
    }
}
