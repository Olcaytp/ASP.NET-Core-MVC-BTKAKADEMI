﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Book"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Electronic"
                        });
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<bool>("GiftWrap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Line2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Line3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Shipped")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            ImageUrl = "/img/1.jpeg",
                            Price = 1800m,
                            ProductName = "Computer",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ImageUrl = "/img/2.jpeg",
                            Price = 250m,
                            ProductName = "Mouse",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ImageUrl = "/img/3.jpeg",
                            Price = 700m,
                            ProductName = "Keyboard",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            ImageUrl = "/img/4.jpeg",
                            Price = 1500m,
                            ProductName = "Monitor",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            ImageUrl = "/img/5.jpeg",
                            Price = 1000m,
                            ProductName = "Headphones",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            ImageUrl = "/img/6.jpeg",
                            Price = 25m,
                            ProductName = "History",
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            ImageUrl = "/img/7.jpeg",
                            Price = 45m,
                            ProductName = "Hamlet",
                            Summary = ""
                        });
                });

            modelBuilder.Entity("Entities.Models.CartLine", b =>
                {
                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderId");

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
