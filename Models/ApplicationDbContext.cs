using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnixAuto.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<ModelDetail> CarDetails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CarManufacturer>().ToTable("CarManufacturer");
            builder.Entity<CarModel>().ToTable("CarModel");
            builder.Entity<ModelDetail>().ToTable("ModelDetail");

            builder.Entity<CarModel>()
                .HasOne(a => a.CarManufacturer)
                .WithMany(c => c.CarModels)
                .HasForeignKey(a => a.CarManufacturerId);

            builder.Entity<CarModel>()
                .HasOne(a => a.ModelDetail)
                .WithOne(c => c.CarModel)
                .HasForeignKey<CarModel>(c => c.ModelDetailId);
        }
    }
}
