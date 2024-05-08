package com.quiz.controller;

import com.quiz.model.Category;
import com.quiz.service.QuizService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;


@Controller
public class HomeController {


    @Autowired
    private QuizService quizService;

    @GetMapping("/login")
    public String login()
    {
        return "userlogin";
    }



    @GetMapping("/home")
    public String home(@AuthenticationPrincipal UserDetails currentUser, Model model) {
        model.addAttribute("user",currentUser.getUsername());
        return "home";
    }

    @GetMapping("/takequiz")
    public ModelAndView takeQuiz() {
        ModelAndView modelAndView = new ModelAndView();
        List<Category> quizTopics = quizService.getAllQuizCategory();
        modelAndView.addObject("quizTopics", quizTopics);
        modelAndView.setViewName("takequiz");
        return modelAndView;
    }
}
