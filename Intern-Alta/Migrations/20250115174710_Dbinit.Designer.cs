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
    [Migration("20250115174710_Dbinit")]
    partial class Dbinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Intern_Alta.Data.Flight", b =>
                {
                    b.Property<int>("FlightsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightsID"), 1L, 1);

                    b.Property<DateTime>("Departure")
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
#pragma warning restore 612, 618
        }
    }
}
