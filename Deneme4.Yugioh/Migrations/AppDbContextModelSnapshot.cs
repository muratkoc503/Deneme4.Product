﻿// <auto-generated />
using Deneme4.Yugioh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deneme4.Yugioh.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Deneme4.Yugioh.Models.YugiohCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("Attack")
                        .HasColumnType("int")
                        .HasColumnName("Attack");

                    b.Property<string>("Attribute")
                        .HasColumnType("longtext")
                        .HasColumnName("Attribute");

                    b.Property<int>("Defence")
                        .HasColumnType("int")
                        .HasColumnName("Defence");

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.Property<int>("Password")
                        .HasColumnType("int")
                        .HasColumnName("Password");

                    b.Property<string>("SubType")
                        .HasColumnType("longtext")
                        .HasColumnName("SubType");

                    b.Property<string>("Text")
                        .HasColumnType("longtext")
                        .HasColumnName("Text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Yugioh");
                });
#pragma warning restore 612, 618
        }
    }
}
