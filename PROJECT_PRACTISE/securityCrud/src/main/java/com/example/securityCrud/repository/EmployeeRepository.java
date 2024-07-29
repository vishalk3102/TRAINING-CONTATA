package com.example.securityCrud.repository;

import com.example.securityCrud.entity.Employee;
import org.springframework.data.jpa.repository.JpaRepository;

public interface EmployeeRepository extends JpaRepository<Employee,Integer> {
    Employee findByEmail(String email);

}
