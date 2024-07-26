package com.example.securityCrud.service;

import com.example.securityCrud.entity.Employee;

import java.util.List;

public interface EmployeeService {
    List<Employee> getAllEmployees();
    Employee getEmployeeById(int Id);
    void saveEmployee(Employee employee);
    void deleteEmployee(int Id);
}
