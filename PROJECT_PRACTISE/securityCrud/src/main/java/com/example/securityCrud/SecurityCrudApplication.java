package com.example.securityCrud;

import com.example.securityCrud.dto.EmployeeDto;
import com.example.securityCrud.entity.Employee;
import com.example.securityCrud.entity.Role;
import com.example.securityCrud.repository.EmployeeRepository;
import io.swagger.v3.oas.annotations.OpenAPIDefinition;
import io.swagger.v3.oas.annotations.enums.SecuritySchemeIn;
import io.swagger.v3.oas.annotations.enums.SecuritySchemeType;
import io.swagger.v3.oas.annotations.info.Info;
import io.swagger.v3.oas.annotations.security.SecurityRequirement;
import io.swagger.v3.oas.annotations.security.SecurityScheme;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.ApplicationRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.security.crypto.password.PasswordEncoder;

@SpringBootApplication
@OpenAPIDefinition(info = @Info(title = "Employees API", version = "1.0", description = "Employees Information"),security = @SecurityRequirement(name="bearerAuth"))
@SecurityScheme(
        name = "jwtAuthentication",
        type = SecuritySchemeType.HTTP,
        scheme = "bearer",
        bearerFormat = "JWT"
)
public class SecurityCrudApplication {

    public static void main(String[] args) {
        SpringApplication.run(SecurityCrudApplication.class, args);
    }

    @Autowired
    private PasswordEncoder passwordEncoder;

    @Bean
    public ApplicationRunner initializer(EmployeeRepository repository) {
        return args -> {
            if (repository.findByEmail("vishal.k3102@gmail.com") == null) {
                Employee employee = new Employee("Vishal", "Kumar", "vishal.k3102@gmail.com", passwordEncoder.encode("12345"), Role.EMPLOYEE);
                repository.save(employee);
            }
            if (repository.findByEmail("vishal@gmail.com") == null) {
                Employee employee = new Employee("Vishal", "Kumar", "vishal@gmail.com", passwordEncoder.encode("12345"), Role.ADMIN);
                repository.save(employee);
            }
        };
    }

}
