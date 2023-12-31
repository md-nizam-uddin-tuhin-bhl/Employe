﻿// <auto-generated />
using System;
using Employe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employe.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20230908033636_in")]
    partial class @in
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Employe.Models.Attendance", b =>
                {
                    b.Property<long>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AttendanceId"), 1L, 1);

                    b.Property<DateTime?>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsAbsent")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOffDay")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPresent")
                        .HasColumnType("bit");

                    b.HasKey("AttendanceId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("Employe.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EmployeeId"), 1L, 1);

                    b.Property<string>("EmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeSalary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Employe.Models.Attendance", b =>
                {
                    b.HasOne("Employe.Models.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Employe.Models.Employee", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
