package com.example.securityCrud.controller;

import com.example.securityCrud.dto.EmployeeDto;
import com.example.securityCrud.entity.Employee;
import com.example.securityCrud.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.security.Principal;
import java.util.List;


@RestController
@RequestMapping
public class EmployeeController {

    @Autowired
    private EmployeeService employeeService;


    @PreAuthorize("hasRole('ADMIN') or hasRole('EMPLOYEE')")
    @GetMapping("/")
    public String Home()
    {
        return "this is home page";
    }

    @PreAuthorize("hasRole('EMPLOYEE')")
    @GetMapping("/profile")
    public String Profile(Principal principal)
    {
        return principal.getName();
    }

    @PreAuthorize("hasRole('ADMIN')")
    @GetMapping("/admin/")
    public List<Employee> getAllEmployee()
    {
        return employeeService.getAllEmployees();
    }


    @PreAuthorize("hasRole('ADMIN')")
    @GetMapping("/admin/{id}")
    public Employee getEmployeeById(@PathVariable int id)
    {
        return employeeService.getEmployeeById(id);
    }


    @PreAuthorize("hasRole('ADMIN')")
    @PostMapping("/admin/register")
    public ResponseEntity<?> createEmployee(@RequestBody EmployeeDto employeeDto)
    {
        employeeService.save(employeeDto);
        return ResponseEntity.ok("Employee registered successfully");
    }

//    @PostMapping("/add")
//    public ResponseEntity<?> addEmployee(@RequestBody EmployeeDto employeeDto)
//    {
//        employeeService.save(employeeDto);
//        return ResponseEntity.ok("Employee registered successfully");
//    }



    @PreAuthorize("hasRole('ADMIN')")
    @DeleteMapping("/admin/{id}")
    public ResponseEntity<?> deleteEmployee(@PathVariable int id)
    {
      employeeService.deleteEmployee(id);
      return ResponseEntity.ok("Employee deleted successfully");
    }
}
