using server.Services;
using Microsoft.AspNetCore.Mvc;
using server.Model;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers
{
    [ApiController]
    [Route("/api/v1/")]
    public  class EmployeeController: Controller
    {
        private readonly EmployeeService _employeeServiceDb;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeServiceDb = employeeService;
        }



        //GET ALL EMPLOYEES FROM  DATABASE
        [HttpGet("admin/employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeServiceDb.getAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        //GET  EMPLOYEE BY EMPID FROM  DATABASE
        [HttpGet("employee/{empId}")]
        public async Task<IActionResult> GetEmployee(int empId)
        {
            try
            {
                var employee = await _employeeServiceDb.getEmployee(empId);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
          
        }

        //ADD EMPLOYEE DETAILS  TO DATABASE

        [HttpPost("admin/employee/add")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                await _employeeServiceDb.addEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { empId = employee.empId }, employee);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        //UPDATE  EMPLOYEE DETAILS
        [HttpPut("admin/employee/{empId}")]
        public async Task<IActionResult> UpdateEmployee(Employee employee, int empId)
        {
            try
            {
                if (empId != employee.empId)
                {
                    return BadRequest();
                }

                await _employeeServiceDb.updateEmployee(employee); ;
                return Ok("Employee Updated Successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }




        //DELETE  EMPLOYEE DETAILS
        [HttpDelete("admin/employee/{empId}")]
        public async Task<IActionResult> DeleteEmployee(int empId)
        {
            try
            {
                var employee = await _employeeServiceDb.getEmployee(empId);
                if (employee == null)
                {

                    return NotFound();
                }
                await _employeeServiceDb.deleteEmployee(empId);
                return Ok("Employee Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }

           
        }

    }
}