package com.quiz.model;

import jakarta.persistence.*;

import java.time.LocalDateTime;

@Entity
public class AttemptedQuiz {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int attemptID;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "userId",nullable=false)
    private Users user;

    @Column(nullable=false)
    private int quizID;

    @Column(nullable=false)
    private int score;

    @Column(nullable=false)
    private LocalDateTime attemptedAt;


    public int getAttemptID() {
        return attemptID;
    }

    public void setAttemptID(int attemptID) {
        this.attemptID = attemptID;
    }

    public Users getUserId() {
        return user;
    }

    public void setUserId(Users user) {
        this.user = user;
    }

    public int getQuizID() {
        return quizID;
    }

    public void setQuizID(int quizID) {
        this.quizID = quizID;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }

    public LocalDateTime getAttemptedAt() {
        return attemptedAt;
    }

    public void setAttemptedAt(LocalDateTime attemptedAt) {
        this.attemptedAt = attemptedAt;
    }
}
