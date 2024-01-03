﻿// <auto-generated />
using System;
using Driver.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Driver.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240103095801_updated-migration")]
    partial class updatedmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Driver.Entities.DbSet.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uuid");

                    b.Property<int>("FastestLap")
                        .HasColumnType("integer");

                    b.Property<int>("PolePosition")
                        .HasColumnType("integer");

                    b.Property<int>("RaceWins")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("WorldChampionship")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Driver.Entities.DbSet.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DriverNumber")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Driver.Entities.DbSet.Achievement", b =>
                {
                    b.HasOne("Driver.Entities.DbSet.Driver", "Driver")
                        .WithMany("Achievements")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Achievements_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Driver.Entities.DbSet.Driver", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}