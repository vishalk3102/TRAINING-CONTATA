﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxManagementNew.Data;

#nullable disable

namespace TaxManagementNew.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240627091832_added-changerequest-table")]
    partial class addedchangerequesttable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasData(
                        new
                        {
                            Id = "6e85f99e-2d9b-4620-a381-d4a57845b30d",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "c080ff7e-dfa5-4642-b0ac-1493b384ab36",
                            Name = "client",
                            NormalizedName = "client"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TaxManagementNew.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PanNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
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

                    b.HasData(
                        new
                        {
                            Id = "7f49676f-2ef5-444b-a292-3873b99c96b7",
                            AccessFailedCount = 0,
                            Address = "123 Main St, City, Country",
                            Age = 22,
                            ConcurrencyStamp = "0bbc7313-52e1-4f35-8c4f-642f82f67fc0",
                            DateOfBirth = new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            EmpId = 1000,
                            LockoutEnabled = false,
                            Name = "Vishal Kumar",
                            PanNo = "ABCDE1234F",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "257fcad8-acf7-4974-b0e5-5333c637b5ba",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("TaxManagementNew.Models.ChangeRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("taxId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ChangeRequests");

                    b.HasData(
                        new
                        {
                            id = 1,
                            reason = "Wrong",
                            taxId = 1
                        },
                        new
                        {
                            id = 2,
                            reason = "Wrong",
                            taxId = 2
                        });
                });

            modelBuilder.Entity("TaxManagementNew.Models.TaxDeclaration", b =>
                {
                    b.Property<int>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxId"));

                    b.Property<decimal>("AnyOtherIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BankFixedDeposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DateOfDeclaration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("FinancialYear")
                        .HasColumnType("int");

                    b.Property<decimal>("HigherEducationLoanInterest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HouseRent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestHousingLoan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("LTA")
                        .HasColumnType("bit");

                    b.Property<decimal>("LifeInsurancePremium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MediClaim")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NPS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PPF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PreventiveHealthCheckUp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrincipalHousingLoan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SukanyaSamriddhiAccount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TDS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TuitionFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("isDrafted")
                        .HasColumnType("bit");

                    b.Property<bool>("isFrozen")
                        .HasColumnType("bit");

                    b.Property<bool>("isRejected")
                        .HasColumnType("bit");

                    b.Property<bool>("isSubmitted")
                        .HasColumnType("bit");

                    b.HasKey("TaxId");

                    b.ToTable("TaxDeclarations");

                    b.HasData(
                        new
                        {
                            TaxId = 1,
                            AnyOtherIncome = 0m,
                            BankFixedDeposit = 40000m,
                            DateOfDeclaration = "2024-04-28",
                            EmpId = 1001,
                            FinancialYear = 2025,
                            HigherEducationLoanInterest = 20000m,
                            HouseRent = 20000m,
                            InterestHousingLoan = 25000m,
                            LTA = true,
                            LifeInsurancePremium = 25000m,
                            MediClaim = 15000m,
                            NPS = 30000m,
                            PPF = 20000m,
                            PreventiveHealthCheckUp = 10000m,
                            PrincipalHousingLoan = 35000m,
                            Status = "accepted",
                            SukanyaSamriddhiAccount = 15000m,
                            TDS = 25000m,
                            TuitionFee = 30000m,
                            isAccepted = true,
                            isDrafted = false,
                            isFrozen = false,
                            isRejected = false,
                            isSubmitted = false
                        },
                        new
                        {
                            TaxId = 2,
                            AnyOtherIncome = 0m,
                            BankFixedDeposit = 40000m,
                            DateOfDeclaration = "2024-04-28",
                            EmpId = 1001,
                            FinancialYear = 2025,
                            HigherEducationLoanInterest = 20000m,
                            HouseRent = 20000m,
                            InterestHousingLoan = 25000m,
                            LTA = true,
                            LifeInsurancePremium = 25000m,
                            MediClaim = 15000m,
                            NPS = 30000m,
                            PPF = 20000m,
                            PreventiveHealthCheckUp = 10000m,
                            PrincipalHousingLoan = 35000m,
                            Status = "rejected",
                            SukanyaSamriddhiAccount = 15000m,
                            TDS = 25000m,
                            TuitionFee = 30000m,
                            isAccepted = false,
                            isDrafted = false,
                            isFrozen = false,
                            isRejected = true,
                            isSubmitted = false
                        });
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
                    b.HasOne("TaxManagementNew.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TaxManagementNew.Models.ApplicationUser", null)
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

                    b.HasOne("TaxManagementNew.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TaxManagementNew.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
