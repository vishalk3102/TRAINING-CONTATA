package com.quiz.repository;

import com.quiz.model.Question;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
public interface QuestionRepository extends JpaRepository<Question,Integer> {
    List<Question> findByCategoryIdAndIsMultichoice(Long quizTopicId, boolean isMultichoice);
}
