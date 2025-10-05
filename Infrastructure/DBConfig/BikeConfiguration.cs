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
        }
    }
}
