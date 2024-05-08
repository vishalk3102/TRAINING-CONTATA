package com.quiz.service;

import com.quiz.model.Question;
import com.quiz.repository.QuestionRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;


@Service
public class QuestionService {

    private final QuestionRepository questionRepository;

    public QuestionService(QuestionRepository questionRepository)
    {
        this.questionRepository=questionRepository;
    }


    public List<Question> getQuestionByCategory(Long quizTopicId, boolean isMultichoice)
    {
        return questionRepository.findByCategoryIdAndIsMultichoice(quizTopicId, isMultichoice);
    }

    public Question getAnswers(Integer questionId)
    {
        Optional<Question> questionResult=questionRepository.findById(questionId);
        return questionResult.orElse(null);
    }
}
