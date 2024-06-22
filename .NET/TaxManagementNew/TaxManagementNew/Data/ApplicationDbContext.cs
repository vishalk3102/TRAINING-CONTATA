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
    }
}
