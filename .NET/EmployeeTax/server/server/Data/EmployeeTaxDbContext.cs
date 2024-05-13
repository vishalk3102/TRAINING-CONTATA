using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace server.Data
{

    public class EmployeeTaxDbContext:DbContext
    {
        public EmployeeTaxDbContext(DbContextOptions<EmployeeTaxDbContext>options):base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaxDeclaration>TaxDeclarations { get; set; }
        public DbSet<ChangeRequest> ChangeRequests{ get; set; }



        // LOGIN 
        public async  Task<LoginResult> Login(int empId, string password)
        {
            var employee = await Employees.FirstOrDefaultAsync(e => e.empId == empId);

            if (employee != null)
            {
                if (employee.password == password)
                {
                    return new LoginResult { Success = true, Data = employee };
                }
            }

            return new LoginResult { Success = false };
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //      SEED DATA

            // Configure Employee entity --seed data 
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                    empId = 1,
                    name = "Vishal Kumar",
                    dateOfBirth= "2002-01-31",
                    age = 22,
                    gender = "Male",
                    phoneNumber = "1234567890",
                    panNo = "ABCDE1234F",
                    address = "123 Main St, City, Country",
                    role = "admin",
                    password = "admin@123"
               },
                new Employee
                {
                    empId = 2,
                    name = "Vishal",
                    dateOfBirth = "2002-01-31",
                    age = 21,
                    gender = "Male",
                    phoneNumber = "8459126643",
                    panNo = "ABCDE1234F",
                    address = "123 Main St, City, Country",
                    role = "employee",
                    password = "emp@123"
                }
             );

            // Configure TaxDeclaration entity
            modelBuilder.Entity<TaxDeclaration>().HasData(
              new TaxDeclaration
              {
                  taxId = 1,
                  empId = 1,
                  sukanyaSamriddhiAccount = 15000,
                  PPF = 20000,
                  lifeInsurancePremium = 25000,
                  tuitionFee = 30000,
                  bankFixedDeposit = 40000,
                  principalHousingLoan = 35000,
                  NPS = 30000,
                  higherEducationLoanInterest = 20000,
                  interestHousingLoan = 25000,
                  houseRent = 20000,
                  TDS = 25000,
                  mediClaim = 15000,
                  preventiveHealthCheckUp = 10000,
                  LTA = true,
                  financialYear = 2025,
                  dateOfDeclaration = "2024-04-28",
                  status = "drafted",
                  isSubmitted = false
              },
               new TaxDeclaration
               {

                   taxId = 2,
                   empId = 2,
                   sukanyaSamriddhiAccount = 15000,
                   PPF = 20000,
                   lifeInsurancePremium = 25000,
                   tuitionFee = 30000,
                   bankFixedDeposit = 40000,
                   principalHousingLoan = 35000,
                   NPS = 30000,
                   higherEducationLoanInterest = 20000,
                   interestHousingLoan = 25000,
                   houseRent = 20000,
                   TDS = 25000,
                   mediClaim = 15000,
                   preventiveHealthCheckUp = 10000,
                   LTA = true,
                   financialYear = 2024,
                   dateOfDeclaration = "2024-04-25",
                   status = "drafted",
                   isSubmitted = false
               }
             );

            modelBuilder.Entity<ChangeRequest>().HasData(
              new ChangeRequest
              {
                  id=1,
                  taxId = 1,
                  reason = "Wrong",
              },
              new ChangeRequest
              {
                  id=2,
                  taxId = 2,
                  reason = "Wrong",
              }
            );
        }
    }


    //MODEL SCHEMA FOR LOGIN RESPOSNE
    public class LoginResult
    {
        public bool Success { get; set; }
        public Employee Data { get; set; }
    }

}