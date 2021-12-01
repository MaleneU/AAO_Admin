using AAO_AdminPanel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Data
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(options)
        {

        }

        public DbSet<Trip> Trip { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DriverLicense> DriverLicense { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<StartLocation> StartLocation { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Traffic> Traffic { get; set; }
        public DbSet<TrafficType> Type { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Address> Address { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<>(e => e.Property(o => o.Age).HasColumnType("tinyint(1)").HasConversion<short>());
        //    //modelBuilder.Entity<Person>(e => e.Property(o => o.IsPlayer).HasConversion(new BoolToZeroOneConverter<Int16>()).HasColumnType("bit"));
        //}
    }
}
