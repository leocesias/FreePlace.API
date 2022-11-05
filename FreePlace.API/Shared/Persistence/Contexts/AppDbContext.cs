using FreePlace.API.ParkingLots.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Parking> Parkings { get; set; }
    
    public AppDbContext(DbContextOptions options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Parking Entity Mapping
        builder.Entity<Parking>().ToTable("Parking");
        builder.Entity<Parking>().HasKey(p => p.Id);
        builder.Entity<Parking>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Parking>().Property(p => p.Capacity).IsRequired();
        builder.Entity<Parking>().Property(p => p.Description).IsRequired().HasMaxLength(250);
        builder.Entity<Parking>().Property(p => p.Ubication).IsRequired().HasMaxLength(100);
        builder.Entity<Parking>().Property(p => p.Price).IsRequired();

        // Car Entity Mapping
        builder.Entity<Car>().ToTable("Cars");
        builder.Entity<Car>().HasKey(p => p.Id);
        builder.Entity<Car>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(p => p.Plate).IsRequired().HasMaxLength(10);
        builder.Entity<Car>().Property(p => p.ParkedTime).IsRequired();
        
        //Relationships
        /*
        builder.Entity<Parking>()
            .HasMany(p => p.Car)
            .WithOne(p => p.Parking)
            .HasForeignKey(p => p.ParkingId);
        */
    }
    
}