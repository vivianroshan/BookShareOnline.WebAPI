﻿// <auto-generated />
using System;
using BookShareOnline.WebAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookShareOnline.WebAPI.Data.Migrations
{
    [DbContext(typeof(BookShareContext))]
    [Migration("20210927102600_Added PhotoFile")]
    partial class AddedPhotoFile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookShareOnline.WebAPI.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Seller")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookShareOnline.WebAPI.Data.Models.CartEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Buyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BookShareOnline.WebAPI.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Buyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookShareOnline.WebAPI.Data.Models.CartEntry", b =>
                {
                    b.HasOne("BookShareOnline.WebAPI.Data.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookShareOnline.WebAPI.Data.Models.Order", b =>
                {
                    b.HasOne("BookShareOnline.WebAPI.Data.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
