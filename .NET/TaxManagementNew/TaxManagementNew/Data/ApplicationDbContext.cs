using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TaxManagementNew.Models;

namespace TaxManagementNew.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users {  get; set; }
    public DbSet<TaxDeclaration> TaxDeclarations { get; set; }
    public DbSet<ChangeRequest> ChangeRequests{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";

        var client = new IdentityRole("client");
        client.NormalizedName = "client";

        builder.Entity<IdentityRole>().HasData(admin, client);

        builder.Entity<ApplicationUser>().HasData(
             new ApplicationUser
             {
                 EmpId = 1000,
                 Name = "Vishal Kumar",
                 DateOfBirth = new DateTime(2002, 1, 31),
                 Age = 22,
                 PhoneNumber = "1234567890",
                 PanNo = "ABCDE1234F",
                 Address = "123 Main St, City, Country",
             });
        // Configure TaxDeclaration entity
        builder.Entity<TaxDeclaration>().HasData(
          new TaxDeclaration
          {
              TaxId = 1,
              EmpId = 1001,
              SukanyaSamriddhiAccount = 15000,
              PPF = 20000,
              LifeInsurancePremium = 25000,
              TuitionFee = 30000,
              BankFixedDeposit = 40000,
              PrincipalHousingLoan = 35000,
              NPS = 30000,
              HigherEducationLoanInterest = 20000,
              InterestHousingLoan = 25000,
              HouseRent = 20000,
              TDS = 25000,
              MediClaim = 15000,
              PreventiveHealthCheckUp = 10000,
              LTA = true,
              FinancialYear = 2025,
              DateOfDeclaration = "2024-04-28",
              Status = "accepted",
              isSubmitted = false,
              isAccepted = true,
              isDrafted = false,
              isRejected = false
          },
           new TaxDeclaration
           {

               TaxId = 2,
               EmpId = 1001,
               SukanyaSamriddhiAccount = 15000,
               PPF = 20000,
               LifeInsurancePremium = 25000,
               TuitionFee = 30000,
               BankFixedDeposit = 40000,
               PrincipalHousingLoan = 35000,
               NPS = 30000,
               HigherEducationLoanInterest = 20000,
               InterestHousingLoan = 25000,
               HouseRent = 20000,
               TDS = 25000,
               MediClaim = 15000,
               PreventiveHealthCheckUp = 10000,
               LTA = true,
               FinancialYear = 2025,
               DateOfDeclaration = "2024-04-28",
               Status = "rejected",
               isSubmitted = false,
               isAccepted = false,
               isDrafted = false,
               isRejected = true
           }
         );

        builder.Entity<ChangeRequest>().HasData(
          new ChangeRequest
          {
              Id = 1,
              TaxId = 1,
              Reason = "Wrong",
          },
          new ChangeRequest
          {
              Id = 2,
              TaxId = 2,
              Reason = "Wrong",
          }
        );
    }
}
