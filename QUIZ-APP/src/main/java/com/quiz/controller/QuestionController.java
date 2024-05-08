package com.quiz.controller;

import com.quiz.model.Question;
import com.quiz.service.QuestionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;


@Controller
public class QuestionController {


    private final QuestionService questionService;


    @Autowired
    public QuestionController(QuestionService questionService) {
        this.questionService = questionService;
    }


    @GetMapping("/question/{quizTopicId}")
    public ModelAndView showQuestions(@PathVariable Long quizTopicId, @AuthenticationPrincipal UserDetails currentUser) {
        ModelAndView modelAndView = new ModelAndView();
        List<Question> mulQuestions = questionService.getQuestionByCategory(quizTopicId, true);
        List<Question> mcqQuestions = questionService.getQuestionByCategory(quizTopicId, false);

        List<Question> questions = new ArrayList<>();
        Collections.shuffle(mulQuestions);
        Collections.shuffle(mcqQuestions);
        questions.addAll(mulQuestions.subList(0,3));
        questions.addAll(mcqQuestions.subList(0,7));

        modelAndView.addObject("questions", questions);
        modelAndView.addObject("userId",currentUser.getUsername());
        modelAndView.addObject("quizId",quizTopicId);
        modelAndView.setViewName("quizForm");
        return modelAndView;
    }
}
