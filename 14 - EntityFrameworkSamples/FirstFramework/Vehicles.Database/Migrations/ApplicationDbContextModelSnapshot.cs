﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehicles.Database;

#nullable disable

namespace Vehicles.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vehicles.Database.Entities.CityEntity", b =>
                {
                    b.Property<long>("PostalCode")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PostalCode");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ColorEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Code", "Name")
                        .IsUnique();

                    b.ToTable("Color");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "ffffff",
                            Name = "White"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "000000",
                            Name = "Black"
                        },
                        new
                        {
                            Id = 3L,
                            Code = "ff0000",
                            Name = "Red"
                        },
                        new
                        {
                            Id = 4L,
                            Code = "ffff00",
                            Name = "Yellow"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ManufacturerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ISOCountryCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ManufacturerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.OwnerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("StreetId")
                        .HasColumnType("bigint");

                    b.Property<string>("TAJ")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.HasIndex("TAJ")
                        .IsUnique();

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.StreetEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CityPostalCode")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityPostalCode");

                    b.ToTable("Street");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<long>("ColorId")
                        .HasColumnType("bigint");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("LisencePlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<long>("ModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("NumberOfDoors")
                        .HasColumnType("bigint");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("Power")
                        .HasColumnType("bigint");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsageID")
                        .HasColumnType("bigint");

                    b.Property<long>("VehicleTypeId")
                        .HasColumnType("bigint");

                    b.Property<int>("VehicleUsageId")
                        .HasColumnType("int");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("LisencePlate")
                        .IsUnique();

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("VehicleTypeId");

                    b.HasIndex("VehicleUsageId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleTypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Car"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Truck"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Motorcycle"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Van"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleUsageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Usage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Normal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Taxi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Freight"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Company"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.OwnerEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.StreetEntity", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.StreetEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.CityEntity", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityPostalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.ColorEntity", "Color")
                        .WithMany("Vehicles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.ModelEntity", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.OwnerEntity", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.VehicleTypeEntity", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.VehicleUsageEntity", "VehicleUsage")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleUsageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Model");

                    b.Navigation("Owner");

                    b.Navigation("VehicleType");

                    b.Navigation("VehicleUsage");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.CityEntity", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ColorEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.OwnerEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleTypeEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleUsageEntity", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
