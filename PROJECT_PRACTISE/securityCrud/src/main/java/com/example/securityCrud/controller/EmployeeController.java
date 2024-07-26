package com.example.securityCrud.controller;

import com.example.securityCrud.entity.Employee;
import com.example.securityCrud.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;


@RestController
@RequestMapping("/")
public class EmployeeController {

    @Autowired
    private EmployeeService employeeService;

    @GetMapping
    public List<Employee> getAllEmployee()
    {
        return employeeService.getAllEmployees();
    }

    @GetMapping("/employee/{id}")
    public Employee getEmployeeById(@PathVariable int Id)
    {
        return employeeService.getEmployeeById(Id);
    }


    @PostMapping("/add")
    public void createEmployee(@RequestBody Employee employee)
    {
        employeeService.saveEmployee(employee);
    }
    @DeleteMapping("/employee/{id}")
    public void deleteEmployee(@PathVariable int Id)
    {
      employeeService.deleteEmployee(Id);
    }
}
