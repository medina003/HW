using EfCoreHw3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreHw3.Data.Contexts
{
    public class AutosalonContext : DbContext
    {

    
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Salon> Salon { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("Autosalon");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Model).IsRequired();
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Color).IsRequired();
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
            }
            
            );
            modelBuilder.Entity<Salon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Car).WithMany(p => p.SalonList).HasForeignKey(e => e.CarId).IsRequired().OnDelete(DeleteBehavior.ClientCascade);
                entity.HasOne(e => e.Brand).WithMany(p => p.SalonList).HasForeignKey(e => e.BrandId).IsRequired().OnDelete(DeleteBehavior.ClientCascade); ;
                entity.Property(e => e.Quantity).IsRequired().HasDefaultValue(0);
            }

            );
        }
    }
}
    

