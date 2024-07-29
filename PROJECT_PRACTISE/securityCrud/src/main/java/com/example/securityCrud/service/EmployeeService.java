package com.example.securityCrud.service;

import com.example.securityCrud.dto.EmployeeDto;
import com.example.securityCrud.entity.Employee;
import org.springframework.security.core.userdetails.UserDetailsService;

import java.util.List;

public interface EmployeeService extends UserDetailsService {
    List<Employee> getAllEmployees();
    Employee getEmployeeById(int Id);
    Employee save(EmployeeDto employeeDto);
    void deleteEmployee(int Id);
}
