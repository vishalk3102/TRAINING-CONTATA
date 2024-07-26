package com.example.securityCrud.service.impl;

import com.example.securityCrud.entity.Employee;
import com.example.securityCrud.repository.EmployeeRepository;
import com.example.securityCrud.service.EmployeeService;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service

public class EmployeeServiceImpl implements EmployeeService {

    EmployeeRepository employeeRepository;

    public EmployeeServiceImpl(EmployeeRepository employeeRepository) {
        this.employeeRepository = employeeRepository;
    }

    @Override
    public List<Employee> getAllEmployees() {
        return employeeRepository.findAll();
    }

    @Override
    public Employee getEmployeeById(int Id) {
         Optional<Employee> optional= employeeRepository.findById(Id);
         Employee employee=null;
         if(optional.isPresent())
         {
             employee=optional.get();
         }
         else
         {
             throw  new RuntimeException(("Employee no found"));
         }
         return employee;
    }

    @Override
    public void saveEmployee(Employee employee) {
          employeeRepository.save(employee);
    }

    @Override
    public void deleteEmployee(int Id) {
         employeeRepository.deleteById(Id);
    }
}
