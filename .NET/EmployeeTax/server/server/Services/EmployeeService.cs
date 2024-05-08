using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Model;
using System.Web.Http.ModelBinding;

namespace server.Services
{
    public class EmployeeService
    {
        private readonly EmployeeTaxDbContext _db;

        public EmployeeService(EmployeeTaxDbContext db)
        {
            _db = db;
        }


        //GET ALL EMPLOYEES
        public async  Task<List<Employee>> getAllEmployees()
        {
            var employees=await _db.Employees.ToListAsync();
            return employees;
        }


        //GET  EMPLOYEE BY EMPID
        public async Task<Employee> getEmployee(int empId)
        {
            var employee = await _db.Employees.FindAsync(empId);
            return employee;
        }


        //ADD  EMPLOYEE 
        public async Task addEmployee([FromBody] Employee employee)
        {
            

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }


        //UPDATE  EMPLOYEE 
        public async Task updateEmployee(Employee employee)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }


        //DELETE  EMPLOYEE 
        public async Task deleteEmployee(int empId)
        {
            var employee=await _db.Employees.FindAsync(empId);
            if(employee != null)
            {
                _db.Employees.Remove(employee);
               await  _db.SaveChangesAsync();
            }
        }
    }
}