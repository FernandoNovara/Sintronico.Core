using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DBConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                   .IsRequired();

            builder.Property(u => u.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.Document)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(u => u.Phone)
                   .HasMaxLength(15);

            builder.Property(u => u.Address)
                   .HasMaxLength(200);

            builder.Property(u => u.Role)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .IsRequired();
        }
    }
}
