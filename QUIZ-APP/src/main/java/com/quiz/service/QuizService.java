package com.quiz.service;

import com.quiz.model.Category;
import com.quiz.repository.QuizRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;


@Service
public class QuizService {


    @Autowired
    private QuizRepository quizRepository;

    public List<Category> getAllQuizCategory()
    {
        return quizRepository.findAll();
    }

    public Category getQuiz(int id)
    {
        Optional<Category> questionCategory =  quizRepository.findById(id);
        return questionCategory.orElse(null);
    }
}
