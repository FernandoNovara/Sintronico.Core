using Domain;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.DBConfig;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SintronicoDBContext : DbContext
{
    public SintronicoDBContext(DbContextOptions<SintronicoDBContext> options)
        : base(options)
    {
    }

    public DbSet<Bike> Bikes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BikeConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
