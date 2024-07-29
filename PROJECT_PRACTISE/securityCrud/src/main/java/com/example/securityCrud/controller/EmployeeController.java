package com.example.securityCrud.controller;

import com.example.securityCrud.dto.EmployeeDto;
import com.example.securityCrud.entity.Employee;
import com.example.securityCrud.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;


@RestController
@RequestMapping("/employee")
public class EmployeeController {

    @Autowired
    private EmployeeService employeeService;

    @GetMapping("/")
    public List<Employee> getAllEmployee()
    {
        return employeeService.getAllEmployees();
    }

    @GetMapping("/{id}")
    public Employee getEmployeeById(@PathVariable int Id)
    {
        return employeeService.getEmployeeById(Id);
    }

    @PostMapping("/register")
    public void createEmployee(@RequestBody EmployeeDto employeeDto)
    {
        employeeService.save(employeeDto);
    }
    @DeleteMapping("/{id}")
    public void deleteEmployee(@PathVariable int Id)
    {
      employeeService.deleteEmployee(Id);
    }
}
