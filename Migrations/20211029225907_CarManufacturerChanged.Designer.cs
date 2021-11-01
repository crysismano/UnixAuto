﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnixAuto.Models;

namespace UnixAuto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211029225907_CarManufacturerChanged")]
    partial class CarManufacturerChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnixAuto.Models.CarManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarManufacturer");
                });

            modelBuilder.Entity("UnixAuto.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("ModelDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarManufacturerId");

                    b.HasIndex("ModelDetailId")
                        .IsUnique();

                    b.ToTable("CarModel");
                });

            modelBuilder.Entity("UnixAuto.Models.ModelDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ModelDetail");
                });

            modelBuilder.Entity("UnixAuto.Models.CarModel", b =>
                {
                    b.HasOne("UnixAuto.Models.CarManufacturer", "CarManufacturer")
                        .WithMany("CarModels")
                        .HasForeignKey("CarManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnixAuto.Models.ModelDetail", "ModelDetail")
                        .WithOne("CarModel")
                        .HasForeignKey("UnixAuto.Models.CarModel", "ModelDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarManufacturer");

                    b.Navigation("ModelDetail");
                });

            modelBuilder.Entity("UnixAuto.Models.CarManufacturer", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("UnixAuto.Models.ModelDetail", b =>
                {
                    b.Navigation("CarModel");
                });
#pragma warning restore 612, 618
        }
    }
}
