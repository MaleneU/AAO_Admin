using AAO_AdminPanel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMySqlConnection.Data
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(options)
        {

        }

        public DbSet<TripModel> Trip { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<AvailabilityModel> Availability { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<DriverLicenseModel> DriverLicense { get; set; }
        public DbSet<DriverModel> Driver { get; set; }
        public DbSet<LicenseModel> License { get; set; }
        public DbSet<RequestModel> Request { get; set; }
        public DbSet<StartLocationModel> StartLocation { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<TrafficModel> Traffic { get; set; }
        public DbSet<TripHasDriverModel> TripHasDriver { get; set; }
        public DbSet<TypeModel> Type { get; set; }
        public DbSet<CityModel> City { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<>(e => e.Property(o => o.Age).HasColumnType("tinyint(1)").HasConversion<short>());
        //    //modelBuilder.Entity<Person>(e => e.Property(o => o.IsPlayer).HasConversion(new BoolToZeroOneConverter<Int16>()).HasColumnType("bit"));
        //}
    }
}
