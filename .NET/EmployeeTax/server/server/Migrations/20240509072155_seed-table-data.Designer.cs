﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Data;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(EmployeeTaxDbContext))]
    [Migration("20240509072155_seed-table-data")]
    partial class seedtabledata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("server.Model.ChangeRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("dateOfSubmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<int>("financialYear")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            dateOfSubmission = "2024-04-21",
                            empId = 1,
                            financialYear = 2024,
                            name = "Vishal Kumar",
                            reason = "Wrong",
                            taxId = 1
                        },
                        new
                        {
                            id = 2,
                            dateOfSubmission = "2024-04-21",
                            empId = 2,
                            financialYear = 2024,
                            name = "Vishal Kumar",
                            reason = "Wrong",
                            taxId = 2
                        });
                });

            modelBuilder.Entity("server.Model.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("dateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("panNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            empId = 1,
                            address = "123 Main St, City, Country",
                            age = 22,
                            dateOfBirth = "2002-01-31",
                            gender = "Male",
                            name = "Vishal Kumar",
                            panNo = "ABCDE1234F",
                            password = "emp@123",
                            phoneNumber = "1234567890",
                            role = "employee"
                        },
                        new
                        {
                            empId = 2,
                            address = "123 Main St, City, Country",
                            age = 21,
                            dateOfBirth = "2002-01-31",
                            gender = "Male",
                            name = "Vishal",
                            panNo = "ABCDE1234F",
                            password = "admin@123",
                            phoneNumber = "8459126643",
                            role = "admin"
                        });
                });

            modelBuilder.Entity("server.Model.TaxDeclaration", b =>
                {
                    b.Property<int>("taxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("taxId"));

                    b.Property<bool>("LTA")
                        .HasColumnType("bit");

                    b.Property<decimal>("NPS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PPF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TDS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("anyOtherIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("bankFixedDeposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("dateOfDeclaration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<int>("financialYear")
                        .HasColumnType("int");

                    b.Property<decimal>("higherEducationLoanInterest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("houseRent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("interestHousingLoan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isFrozen")
                        .HasColumnType("bit");

                    b.Property<decimal>("lifeInsurancePremium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("mediClaim")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("preventiveHealthCheckUp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("principalHousingLoan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("sukanyaSamriddhiAccount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("tuitionFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("taxId");

                    b.ToTable("TaxDeclarations");

                    b.HasData(
                        new
                        {
                            taxId = 1,
                            LTA = true,
                            NPS = 30000m,
                            PPF = 20000m,
                            TDS = 25000m,
                            anyOtherIncome = 0m,
                            bankFixedDeposit = 40000m,
                            dateOfDeclaration = "2024-04-28",
                            empId = 1,
                            financialYear = 2025,
                            higherEducationLoanInterest = 20000m,
                            houseRent = 20000m,
                            interestHousingLoan = 25000m,
                            isFrozen = false,
                            lifeInsurancePremium = 25000m,
                            mediClaim = 15000m,
                            preventiveHealthCheckUp = 10000m,
                            principalHousingLoan = 35000m,
                            status = "accepted",
                            sukanyaSamriddhiAccount = 15000m,
                            tuitionFee = 30000m
                        },
                        new
                        {
                            taxId = 2,
                            LTA = true,
                            NPS = 30000m,
                            PPF = 20000m,
                            TDS = 25000m,
                            anyOtherIncome = 0m,
                            bankFixedDeposit = 40000m,
                            dateOfDeclaration = "2024-04-25",
                            empId = 2,
                            financialYear = 2024,
                            higherEducationLoanInterest = 20000m,
                            houseRent = 20000m,
                            interestHousingLoan = 25000m,
                            isFrozen = false,
                            lifeInsurancePremium = 25000m,
                            mediClaim = 15000m,
                            preventiveHealthCheckUp = 10000m,
                            principalHousingLoan = 35000m,
                            status = "drafted",
                            sukanyaSamriddhiAccount = 15000m,
                            tuitionFee = 30000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
