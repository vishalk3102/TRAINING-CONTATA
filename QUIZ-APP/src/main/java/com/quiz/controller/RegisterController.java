package com.quiz.controller;

import com.quiz.model.Users;
import com.quiz.service.CustomUserDetailsService;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;


@Controller
@RequestMapping("/register")
public class RegisterController {

    private final CustomUserDetailsService customUserDetailsService;

    public RegisterController(CustomUserDetailsService customUserDetailsService) {
        this.customUserDetailsService = customUserDetailsService;
    }

    @GetMapping
    public String showRegistrationForm()
    {
        return "register";
    }

    @PostMapping
    public String registerUser(Users user)
    {
        customUserDetailsService.registerUser(user);
        return "redirect:/login";
    }
}
