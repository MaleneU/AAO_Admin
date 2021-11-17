﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestMySqlConnection.Data;

namespace AAO_AdminPanel.Migrations.MySQLDb
{
    [DbContext(typeof(MySQLDbContext))]
    [Migration("20211117085252_User-initial")]
    partial class Userinitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("AAO_AdminPanel.Models.TripModel", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfTrip")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateAndTime")
                        .HasColumnType("datetime");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TrafficID")
                        .HasColumnType("int");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("TripID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("AAO_AdminPanel.Models.UserModel", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
