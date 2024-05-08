package com.quiz.model;

import java.sql.Date;
import java.time.LocalDate;
import java.util.List;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.PrePersist;

@Entity
public class Users {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    private int userID;

    @Column(unique=true, nullable = false)
    private String username;

    @Column(nullable = false)
    private String password;

    @Column(nullable = false)
    private Date createdAt;

    @Column(nullable = false)
    private String fullName;

    public String getFullName() {
        return fullName;
    }
    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    private Date lastLogin;

    @OneToMany(mappedBy="user",cascade = CascadeType.ALL, fetch  = FetchType.LAZY)
    private List<AttemptedQuiz> attemptedQuiz;

    public String getUsername() {
        return username;
    }
    public void setUsername(String username) {
        this.username = username;
    }
    public int getUserID() {
        return userID;
    }
    public void setUserID(int userID) {
        this.userID = userID;
    }
    public Date getCreatedAt() {
        return createdAt;
    }
    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }
    public Date getLastLogin() {
        return lastLogin;
    }
    public void setLastLogin(Date lastLogin) {
        this.lastLogin = lastLogin;
    }
    public List<AttemptedQuiz> getQuizAttempts() {
        return attemptedQuiz;
    }
    public void setQuizAttempts(List<AttemptedQuiz> quizAttempts) {
        this.attemptedQuiz = attemptedQuiz;
    }
    public String getPassword() {
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }

    @PrePersist
    protected void onCreate()
    {
        this.createdAt= Date.valueOf(LocalDate.now());
    }

    @Override
    public String toString() {
        return "Users{" +
                "userID=" + userID +
                ", username='" + username + '\'' +
                ", password='" + password + '\'' +
                ", createdAt=" + createdAt +
                ", fullName='" + fullName + '\'' +
                ", lastLogin=" + lastLogin +
                ", attemptedQuiz=" + attemptedQuiz +
                '}';
    }
}
