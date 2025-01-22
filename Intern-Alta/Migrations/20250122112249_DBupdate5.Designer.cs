﻿// <auto-generated />
using System;
using Intern_Alta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Intern_Alta.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20250122112249_DBupdate5")]
    partial class DBupdate5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Intern_Alta.Data.Configuration", b =>
                {
                    b.Property<int>("ConfigID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfigID"), 1L, 1);

                    b.Property<string>("ConfigName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConfigValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentTypeID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.HasKey("ConfigID");

                    b.HasIndex("DocumentTypeID");

                    b.HasIndex("PermissionID");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("Intern_Alta.Data.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentID"), 1L, 1);

                    b.Property<int>("DocumentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DocumentID");

                    b.HasIndex("DocumentTypeID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Intern_Alta.Data.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeID"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocumentTypeID");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("Intern_Alta.Data.Flight", b =>
                {
                    b.Property<int>("FlightsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightsID"), 1L, 1);

                    b.Property<DateTime?>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentID")
                        .HasColumnType("int");

                    b.Property<string>("FlightsNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfLoading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfUnloading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Route")
                        .HasColumnType("int");

                    b.HasKey("FlightsID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Intern_Alta.Data.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"), 1L, 1);

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("RoleID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("PermissionID");

                    b.HasIndex("RoleID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Intern_Alta.Data.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Intern_Alta.Data.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("RoleID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Intern_Alta.Data.Configuration", b =>
                {
                    b.HasOne("Intern_Alta.Data.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Intern_Alta.Data.Permission", "Permission")
                        .WithMany("Configurations")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Intern_Alta.Data.Document", b =>
                {
                    b.HasOne("Intern_Alta.Data.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("Intern_Alta.Data.Permission", b =>
                {
                    b.HasOne("Intern_Alta.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Intern_Alta.Data.User", b =>
                {
                    b.HasOne("Intern_Alta.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Intern_Alta.Data.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Intern_Alta.Data.Permission", b =>
                {
                    b.Navigation("Configurations");
                });
#pragma warning restore 612, 618
        }
    }
}
