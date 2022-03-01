﻿// <auto-generated />
using System;
using Hospital_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Hospital_MVC.Models.ApplicantsTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Applicant_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ApplicantsTable");
                });

            modelBuilder.Entity("Hospital_MVC.Models.CNAs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("CNAs");
                });

            modelBuilder.Entity("Hospital_MVC.Models.DoctorsTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DoctorsTable");
                });

            modelBuilder.Entity("Hospital_MVC.Models.NursesTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AssignedID")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AssignedID");

                    b.ToTable("NursesTable");
                });

            modelBuilder.Entity("Hospital_MVC.Models.NursesTable", b =>
                {
                    b.HasOne("Hospital_MVC.Models.DoctorsTable", "Assigned")
                        .WithMany()
                        .HasForeignKey("AssignedID");

                    b.Navigation("Assigned");
                });
#pragma warning restore 612, 618
        }
    }
}
