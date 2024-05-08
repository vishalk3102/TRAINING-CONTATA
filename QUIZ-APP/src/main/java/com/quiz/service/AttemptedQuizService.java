package com.quiz.service;

import com.quiz.model.AttemptedQuiz;
import com.quiz.model.Users;
import com.quiz.repository.AttemptedQuizRepository;
import com.quiz.repository.UserRepository;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.List;

@Service
public class AttemptedQuizService {

    private final AttemptedQuizRepository attemptedQuizRepository;

    private final UserRepository userRepository;

    public AttemptedQuizService(AttemptedQuizRepository attemptedQuizRepository, UserRepository userRepository) {
        this.attemptedQuizRepository = attemptedQuizRepository;
        this.userRepository = userRepository;
    }

    public AttemptedQuiz submitQuizAttempt(String username,int quizId,int score)
    {
        AttemptedQuiz attemptedQuiz=new AttemptedQuiz();
        attemptedQuiz.setUserId(userRepository.findByUsername(username));
        attemptedQuiz.setQuizID(quizId);
        attemptedQuiz.setScore(score);
        attemptedQuiz.setAttemptedAt(LocalDateTime.now());

        return attemptedQuizRepository.save(attemptedQuiz);
    }

    public List<AttemptedQuiz> getUserSubmissions(String username)
    {
        Users user = userRepository.findByUsername(username);
        List<AttemptedQuiz> result = attemptedQuizRepository.findByUser(user);

        return result;
    }

}
