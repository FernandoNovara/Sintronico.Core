using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SintronicoDBContext : DbContext
{
    public SintronicoDBContext(DbContextOptions<SintronicoDBContext> options)
        : base(options)
    {
    }

    public DbSet<Bike> Bikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BikeConfiguration());
        // Acá vas agregando más configuraciones si tenés
    }
}
