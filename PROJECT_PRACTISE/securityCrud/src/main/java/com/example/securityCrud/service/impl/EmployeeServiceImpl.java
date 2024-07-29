package com.example.securityCrud.service.impl;

import com.example.securityCrud.dto.EmployeeDto;
import com.example.securityCrud.entity.Employee;
import com.example.securityCrud.entity.Role;
import com.example.securityCrud.repository.EmployeeRepository;
import com.example.securityCrud.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.Collection;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service

public class EmployeeServiceImpl implements EmployeeService {

    @Autowired
    private EmployeeRepository employeeRepository;


    private BCryptPasswordEncoder passwordEncoder;


    public EmployeeServiceImpl(EmployeeRepository employeeRepository) {
        this.employeeRepository = employeeRepository;
    }

    @Override
    public List<Employee> getAllEmployees() {
        return employeeRepository.findAll();
    }

    @Override
    public Employee getEmployeeById(int Id) {
        Optional<Employee> optional = employeeRepository.findById(Id);
        Employee employee = null;
        if (optional.isPresent()) {
            employee = optional.get();
        } else {
            throw new RuntimeException(("Employee no found"));
        }
        return employee;
    }

    @Override
    public Employee save(EmployeeDto employeeDto) {
        Employee employee = new Employee(employeeDto.getFirstName(), employeeDto.getLastName(), employeeDto.getEmail(), passwordEncoder.encode(employeeDto.getPassword()), (employeeDto.getRole() != null) ? employeeDto.getRole() : Role.EMPLOYEE);

        return employeeRepository.save(employee);
    }

    @Override
    public void deleteEmployee(int Id) {
        employeeRepository.deleteById(Id);
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        Employee employee =employeeRepository.findByEmail(username);
        if(employee==null)
        {
            throw  new UsernameNotFoundException("Invalid username or password");
        }
        return new org.springframework.security.core.userdetails.User(employee.getEmail(),employee.getPassword(),mapRolesToAuthorities(employee.getRole()));
    }


    private Collection<? extends GrantedAuthority> mapRolesToAuthorities(Collection<Role> roles) {
        return roles.stream()
                .map(role -> new SimpleGrantedAuthority("ROLE_" + role.name()))
                .collect(Collectors.toList());
    }

}
