﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Models;

#nullable disable

namespace TopSecretProject.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230222213335_FifthMigration")]
    partial class FifthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Server.Models.TimePunch", b =>
                {
                    b.Property<int>("TimePunchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PunchTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("PunchType")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("TimePunchId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimePunches");
                });

            modelBuilder.Entity("Server.Models.User", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Models.TimePunch", b =>
                {
                    b.HasOne("Server.Models.User", "Employee")
                        .WithMany("Punches")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Server.Models.User", b =>
                {
                    b.Navigation("Punches");
                });
#pragma warning restore 612, 618
        }
    }
}
