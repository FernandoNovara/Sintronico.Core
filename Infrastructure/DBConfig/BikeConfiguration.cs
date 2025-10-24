using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class BikeConfiguration : IEntityTypeConfiguration<Bike>
    {
        public void Configure(EntityTypeBuilder<Bike> builder)
        {
            builder.HasKey(b => b.BikeId);

            builder.Property(b => b.BikeId)
                   .IsRequired();

            builder.Property(b => b.Model)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(b => b.Category)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(b => b.Color)
                   .HasMaxLength(100);

            builder.Property(b => b.State)
                   .IsRequired();

            builder.Property(b => b.CreatedAt)
                   .IsRequired();

            builder.Property(b => b.LastUpdatedAt);

            builder.Property(b => b.Observations)
                   .HasMaxLength(300);

            builder.Property(b => b.Price)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();
        }
    }
}
