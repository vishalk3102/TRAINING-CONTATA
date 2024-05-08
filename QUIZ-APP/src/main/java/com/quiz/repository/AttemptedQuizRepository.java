package com.quiz.repository;

import com.quiz.model.AttemptedQuiz;
import com.quiz.model.Users;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
public interface AttemptedQuizRepository  extends JpaRepository<AttemptedQuiz,Integer> {
    List<AttemptedQuiz> findByUser(Users user);
}
