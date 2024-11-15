using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarStore.Core;
public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EngineType>().HasMany<Car>(c => c.cars)
                                         .WithOne(et => et.EngineType)
                                         .HasForeignKey(et => et.EngineTypeId)
                                         .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Manufacturer>().HasMany<Car>(c => c.cars)
                                         .WithOne(et => et.Manufacturer)
                                         .HasForeignKey(et => et.ManufacturerId)
                                         .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TypeOfCar>().HasMany<Car>(c => c.cars)
                                         .WithOne(et => et.TypeOfCar)
                                         .HasForeignKey(et => et.TypeOfCarId)
                                         .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<VariantOfCar>().HasKey(sc => new { sc.CarId, sc.VariantId });
        modelBuilder.Entity<VariantOfCar>().HasOne<Car>(vc => vc.Car)
                                           .WithMany(c => c.VariantOfCars)
                                           .HasForeignKey(vc => vc.CarId)
                                           .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VariantOfCar>().HasOne<Variant>(vc => vc.Variant)
                                           .WithMany(c => c.VariantOfCars)
                                           .HasForeignKey(vc => vc.VariantId)
                                           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Car>().HasMany<Schedule>(c => c.Schedules)
                                  .WithOne(s => s.Car)
                                  .HasForeignKey(s => s.CarId)
                                  .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().HasMany<Schedule>(c => c.schedules)
                                  .WithOne(s => s.Merchant)
                                  .HasForeignKey(s => s.MerchantId)
                                  .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().HasMany<Schedule>(u => u.schedules)
                                  .WithOne(s => s.Customer)
                                  .HasForeignKey(s => s.CustomerId)
                                  .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var envfile = "D:\\Study\\timeForCoding\\GitHub\\CarStore\\CarStore.Core\\.env";
        DotNetEnv.Env.Load(envfile);
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDetail> Details { get; set; }
    public DbSet<EngineType> EngineTypes { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<TypeOfCar> TypeOfCars { get; set; }
    public DbSet<Variant> variants { get; set; }
    public DbSet<VariantOfCar> variantsOfCars { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Schedule> schedules { get; set; }
}
