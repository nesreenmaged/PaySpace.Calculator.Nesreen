﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySpace.Calculator.Infrastructure.DataAccess;

#nullable disable

namespace PaySpace.Calculator.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(CalculatorContext))]
    partial class CalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("PaySpace.Calculator.Data.Models.CalculatorHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calculator")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Income")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Tax")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CalculatorHistory");
                });

            modelBuilder.Entity("PaySpace.Calculator.Data.Models.CalculatorSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calculator")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("From")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RateType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CalculatorSetting");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Calculator = 0,
                            From = 0m,
                            Rate = 10m,
                            RateType = 0,
                            To = 8350m
                        },
                        new
                        {
                            Id = 2L,
                            Calculator = 0,
                            From = 8351m,
                            Rate = 15m,
                            RateType = 0,
                            To = 33950m
                        },
                        new
                        {
                            Id = 3L,
                            Calculator = 0,
                            From = 33951m,
                            Rate = 25m,
                            RateType = 0,
                            To = 82250m
                        },
                        new
                        {
                            Id = 4L,
                            Calculator = 0,
                            From = 82251m,
                            Rate = 28m,
                            RateType = 0,
                            To = 171550m
                        },
                        new
                        {
                            Id = 5L,
                            Calculator = 0,
                            From = 171551m,
                            Rate = 33m,
                            RateType = 0,
                            To = 372950m
                        },
                        new
                        {
                            Id = 6L,
                            Calculator = 0,
                            From = 372951m,
                            Rate = 35m,
                            RateType = 0
                        },
                        new
                        {
                            Id = 7L,
                            Calculator = 1,
                            From = 0m,
                            Rate = 5m,
                            RateType = 0,
                            To = 199999m
                        },
                        new
                        {
                            Id = 8L,
                            Calculator = 1,
                            From = 200000m,
                            Rate = 10000m,
                            RateType = 1
                        },
                        new
                        {
                            Id = 9L,
                            Calculator = 2,
                            From = 0m,
                            Rate = 17.5m,
                            RateType = 0
                        });
                });

            modelBuilder.Entity("PaySpace.Calculator.Data.Models.PostalCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calculator")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PostalCode");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Calculator = 0,
                            Code = "7441"
                        },
                        new
                        {
                            Id = 2L,
                            Calculator = 1,
                            Code = "A100"
                        },
                        new
                        {
                            Id = 3L,
                            Calculator = 2,
                            Code = "7000"
                        },
                        new
                        {
                            Id = 4L,
                            Calculator = 0,
                            Code = "1000"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
