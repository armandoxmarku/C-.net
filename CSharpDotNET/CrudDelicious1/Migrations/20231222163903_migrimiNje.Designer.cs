﻿// <auto-generated />
using System;
using CrudDelicious1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudDelicious1.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20231222163903_migrimiNje")]
    partial class migrimiNje
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrudDelicious1.Models.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DishCalories")
                        .HasColumnType("int");

                    b.Property<string>("DishChef")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DishDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DishTastiness")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
