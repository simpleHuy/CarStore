using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Helpers;
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
                                         .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Manufacturer>().HasMany<Car>(c => c.cars)
                                         .WithOne(et => et.Manufacturer)
                                         .HasForeignKey(et => et.ManufacturerId)
                                         .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TypeOfCar>().HasMany<Car>(c => c.cars)
                                         .WithOne(et => et.TypeOfCar)
                                         .HasForeignKey(et => et.TypeOfCarId)
                                         .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<VariantOfCar>().HasKey(sc => new { sc.CarId, sc.VariantId });
        modelBuilder.Entity<VariantOfCar>().HasOne<Car>(vc => vc.Car)
                                           .WithMany(c => c.VariantOfCars)
                                           .HasForeignKey(vc => vc.CarId)
                                           .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<VariantOfCar>().HasOne<Variant>(vc => vc.Variant)
                                           .WithMany(c => c.VariantOfCars)
                                           .HasForeignKey(vc => vc.VariantId)
                                           .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Car>().HasOne<CarDetail>(c => c.carDetail)
                                  .WithOne(cd => cd.Car)
                                  .HasForeignKey<CarDetail>(cd => cd.CarId)
                                  .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<CarDetail>().HasKey(cd => new { cd.CarId });

        modelBuilder.Entity<PriceOfCar>().HasMany<Car>(pc => pc.Cars)
                                       .WithOne(c => c.PriceOfCar)
                                       .HasForeignKey(c => c.PriceOfCarId)
                                       .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<NumberSeat>().HasMany<CarDetail>(n => n.CarDetails)
                                        .WithOne(cd => cd.NumberSeat)
                                        .HasForeignKey(cd => cd.NumberSeatId)
                                        .OnDelete(DeleteBehavior.SetNull);


        //modelBuilder.Entity<Car>().HasMany<Schedule>(c => c.Schedules)
        //                          .WithOne(s => s.Car)
        //                          .HasForeignKey(s => s.CarId)
        //                          .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<User>().HasMany<Schedule>(c => c.schedules)
        //                          .WithOne(s => s.Merchant)
        //                          .HasForeignKey(s => s.MerchantId)
        //                          .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<User>().HasMany<Schedule>(u => u.schedules)
        //                          .WithOne(s => s.Customer)
        //                          .HasForeignKey(s => s.CustomerId)
        //                          .OnDelete(DeleteBehavior.Cascade);

        //seeding data
        modelBuilder.Seed();
    }


    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDetail> CarDetails { get; set; }
    public DbSet<EngineType> EngineTypes { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<TypeOfCar> TypeOfCars { get; set; }
    public DbSet<Variant> variants { get; set; }
    public DbSet<VariantOfCar> variantsOfCars { get; set; }
    public DbSet<PriceOfCar> priceOfCars { get; set; }
    public DbSet<NumberSeat> numberSeats { get; set; }
    //public DbSet<User> users { get; set; }
    //public DbSet<Schedule> schedules { get; set; }
}
