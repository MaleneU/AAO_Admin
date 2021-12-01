﻿// <auto-generated />
using System;
using AAO_AdminPanel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    [DbContext(typeof(MySQLDbContext))]
    [Migration("20211201145250_Dbset Country added")]
    partial class DbsetCountryadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("AAO_AdminPanel.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressLine")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AddressID");

                    b.HasIndex("CityID");

                    b.HasIndex("UserID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Availability", b =>
                {
                    b.Property<int>("AvailabilityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AvailabilityID");

                    b.HasIndex("DriverID");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(45)");

                    b.HasKey("CityID");

                    b.HasIndex("CountryID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("CountryName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CountryID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Driver", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StartLocationID")
                        .HasColumnType("int");

                    b.Property<int>("TrafficTypeID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DriverID");

                    b.HasIndex("StartLocationID");

                    b.HasIndex("TrafficTypeID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.DriverLicense", b =>
                {
                    b.Property<int>("DriverLicenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("DriveID")
                        .HasColumnType("int");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("LicenseID")
                        .HasColumnType("int");

                    b.HasKey("DriverLicenseID");

                    b.HasIndex("DriverID");

                    b.HasIndex("LicenseID");

                    b.ToTable("DriverLicense");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.License", b =>
                {
                    b.Property<int>("LicenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LicenseName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("LicenseID");

                    b.ToTable("License");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("DriverID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TripID");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.StartLocation", b =>
                {
                    b.Property<int>("StartLocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(255)");

                    b.HasKey("StartLocationID");

                    b.ToTable("StartLocation");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Traffic", b =>
                {
                    b.Property<int>("TrafficID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("StartCountryCountryID")
                        .HasColumnType("int");

                    b.Property<int>("StopCountryCountryID")
                        .HasColumnType("int");

                    b.Property<int>("TrafficTypeID")
                        .HasColumnType("int");

                    b.HasKey("TrafficID");

                    b.HasIndex("StartCountryCountryID");

                    b.HasIndex("StopCountryCountryID");

                    b.HasIndex("TrafficTypeID");

                    b.ToTable("Traffic");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.TrafficType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(255)");

                    b.HasKey("TypeID");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateAndTime")
                        .HasColumnType("datetime");

                    b.Property<int>("StartLocationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TrafficID")
                        .HasColumnType("int");

                    b.Property<bool>("Urgent")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TripID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("StartLocationID");

                    b.HasIndex("TrafficID");

                    b.HasIndex("UserID");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Firstname")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Lastname")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(45)");

                    b.HasKey("UserID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("RoleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Address", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Availability", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.City", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Driver", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.StartLocation", "StartLocation")
                        .WithMany("Drivers")
                        .HasForeignKey("StartLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.TrafficType", "TrafficType")
                        .WithMany()
                        .HasForeignKey("TrafficTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.User", "User")
                        .WithOne("Driver")
                        .HasForeignKey("AAO_AdminPanel.Models.Driver", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StartLocation");

                    b.Navigation("TrafficType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.DriverLicense", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID");

                    b.HasOne("AAO_AdminPanel.Models.License", "License")
                        .WithMany("DriverLicenses")
                        .HasForeignKey("LicenseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("License");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Request", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.Status", "Status")
                        .WithMany("Requests")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.Trip", "Trip")
                        .WithMany("Requests")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Status");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Traffic", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Country", "StartCountry")
                        .WithMany()
                        .HasForeignKey("StartCountryCountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.Country", "StopCountry")
                        .WithMany()
                        .HasForeignKey("StopCountryCountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.TrafficType", "TrafficType")
                        .WithMany("Traffics")
                        .HasForeignKey("TrafficTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StartCountry");

                    b.Navigation("StopCountry");

                    b.Navigation("TrafficType");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Trip", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Department", "Department")
                        .WithMany("Trips")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.StartLocation", "Startlocation")
                        .WithMany("Trips")
                        .HasForeignKey("StartLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.Traffic", "Traffic")
                        .WithMany()
                        .HasForeignKey("TrafficID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.User", "User")
                        .WithMany("Trips")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Startlocation");

                    b.Navigation("Traffic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.User", b =>
                {
                    b.HasOne("AAO_AdminPanel.Models.Department", "Department")
                        .WithMany("UserID")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AAO_AdminPanel.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Department", b =>
                {
                    b.Navigation("Trips");

                    b.Navigation("UserID");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.License", b =>
                {
                    b.Navigation("DriverLicenses");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.StartLocation", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Status", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.TrafficType", b =>
                {
                    b.Navigation("Traffics");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.Trip", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Driver");

                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
