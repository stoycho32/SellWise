﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SellWise.Data;

#nullable disable

namespace SellWise.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240609181110_AddingFinalPriceInOrderToCalculateTheTotalShiftAmountThatIsSold")]
    partial class AddingFinalPriceInOrderToCalculateTheTotalShiftAmountThatIsSold
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Cashier", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ManufacturerAddress")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ManufacturerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ManufacturerSerialNumber")
                        .HasColumnType("int")
                        .HasComment("Manufacturer EIK");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                            ManufacturerEmail = "bgtabaco@abv.bg",
                            ManufacturerName = "BGTabaco LTD",
                            ManufacturerSerialNumber = 1234567890
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                            ManufacturerEmail = "marlborobg@abv.bg",
                            ManufacturerName = "MarlboroBG LTD",
                            ManufacturerSerialNumber = 1234567890
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                            ManufacturerEmail = "rothmansbg@abv.bg",
                            ManufacturerName = "RothmansBG LTD",
                            ManufacturerSerialNumber = 1234567890
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                            ManufacturerEmail = "drinksbg@abv.bg",
                            ManufacturerName = "DrinksBG",
                            ManufacturerSerialNumber = 1234567890
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            ManufacturerAddress = "ul. Rakovska No 6, bl. 56, vh. A",
                            ManufacturerEmail = "chiochipsbg@abv.bg",
                            ManufacturerName = "ChioBG LTD",
                            ManufacturerSerialNumber = 1234567890
                        });
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("ProductComment")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("ProductDeliveryPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductSellingPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            ManufacturerId = 1,
                            ProductDeliveryPrice = 6.15m,
                            ProductName = "Davidoff Gold",
                            ProductQuantity = 10,
                            ProductSellingPrice = 6.20m
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            ManufacturerId = 3,
                            ProductDeliveryPrice = 5.40m,
                            ProductName = "Karelia blue 100",
                            ProductQuantity = 10,
                            ProductSellingPrice = 5.50m
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            ManufacturerId = 3,
                            ProductDeliveryPrice = 5.10m,
                            ProductName = "Rothmans DarkBlue 100",
                            ProductQuantity = 10,
                            ProductSellingPrice = 5.20m
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            ManufacturerId = 4,
                            ProductDeliveryPrice = 1.15m,
                            ProductName = "Coca-Cola",
                            ProductQuantity = 24,
                            ProductSellingPrice = 2.20m
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            ManufacturerId = 5,
                            ProductDeliveryPrice = 2.10m,
                            ProductName = "Chio-Chips Paprika",
                            ProductQuantity = 6,
                            ProductSellingPrice = 3.20m
                        });
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CashierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<decimal?>("FinalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("FinalizationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDiscountAplied")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SaleStartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalPriceWithDiscount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.SaleProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SaleId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleProducts");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CashierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("FinalizationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ShiftStartTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ShiftTotalAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Cashier", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Cashier", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SellWise.Infrastructure.Data.Models.Cashier", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Cashier", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Sale", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Cashier", "Cashier")
                        .WithMany("CashierSales")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SellWise.Infrastructure.Data.Models.Shift", "Shift")
                        .WithMany("ShiftSales")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cashier");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.SaleProduct", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("SaleProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SellWise.Infrastructure.Data.Models.Sale", "Sale")
                        .WithMany("SaleProducts")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Shift", b =>
                {
                    b.HasOne("SellWise.Infrastructure.Data.Models.Cashier", "Cashier")
                        .WithMany("CashierShifts")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cashier");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Cashier", b =>
                {
                    b.Navigation("CashierSales");

                    b.Navigation("CashierShifts");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Product", b =>
                {
                    b.Navigation("SaleProducts");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Sale", b =>
                {
                    b.Navigation("SaleProducts");
                });

            modelBuilder.Entity("SellWise.Infrastructure.Data.Models.Shift", b =>
                {
                    b.Navigation("ShiftSales");
                });
#pragma warning restore 612, 618
        }
    }
}
