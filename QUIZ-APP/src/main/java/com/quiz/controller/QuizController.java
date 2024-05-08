package com.quiz.controller;


import com.quiz.model.AttemptedQuiz;
import com.quiz.model.Question;
import com.quiz.model.QuestionAnswerDto;
import com.quiz.service.AttemptedQuizService;
import com.quiz.service.QuestionService;
import com.quiz.service.QuizService;
import jakarta.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.*;

@Controller
public class QuizController {
    private int total=10,correct=0;
    private final AttemptedQuizService attemptedQuizService;
    private final QuestionService questionService;
    private final QuizService quizService;


    @Autowired
    public QuizController(AttemptedQuizService attemptedQuizService, QuestionService questionService, QuizService quizService) {
        this.attemptedQuizService = attemptedQuizService;
        this.questionService = questionService;
        this.quizService = quizService;
    }

    @PostMapping("/question/submitQuiz")/*QuizAttempts*/
    public String submitQuiz(HttpServletRequest request, Model model) {
        // Extract form parameters
        int quizId = Integer.parseInt(request.getParameter("quizId"));
        String username = request.getParameter("username");

        // Extract selected options for each question
        List<QuestionAnswerDto> questionAnswers = new ArrayList<>();
        Enumeration<String> parameterNames = request.getParameterNames();
        while (parameterNames.hasMoreElements()) {
            String paramName = parameterNames.nextElement();
            if (paramName.startsWith("selectedOptions")) {
                String[] selectedOptions = request.getParameterValues(paramName);
                if (selectedOptions != null && selectedOptions.length > 0) {
                    String questionIdStr = paramName.substring("selectedOptions".length());
                    int questionId = Integer.parseInt(questionIdStr);
                    QuestionAnswerDto questionAnswer = new QuestionAnswerDto();
                    questionAnswer.setQuestionId(questionId);
                    questionAnswer.setSelectedOptions(Arrays.asList(selectedOptions));
                    questionAnswers.add(questionAnswer);
                }
            }
        }
        int totalScore = calculateScore(questionAnswers);
        model.addAttribute("score",totalScore);
        model.addAttribute("name",username);
        model.addAttribute("correctAnswers",correct);
        model.addAttribute("incorrectAnswers",total-correct);
        attemptedQuizService.submitQuizAttempt(username, quizId, totalScore);
        return "quizScore";
    }

    private int calculateScore(List<QuestionAnswerDto> submission) {
        int totalScore = 0;
        for (QuestionAnswerDto qdto : submission) {
            Question question = questionService.getAnswers(qdto.getQuestionId());
            if (question.isMultichoice()) {
                String[] correctAnswers = question.getCorrectAnswer().split(",");
                List<String> correctAnswersList = Arrays.asList(correctAnswers);
                List<String> selectedOptions = qdto.getSelectedOptions();

                // Calculate the number of correct selections
                int correctSelections = 0;
                for (String selectedOption : selectedOptions) {
                    if (correctAnswersList.contains(selectedOption.trim())) {
                        correctSelections++;
                    }
                }


                totalScore += calculateScoreForSelections(correctSelections, correctAnswersList.size());

                if (correctSelections > 0) {
                    correct++;
                }
            } else {
                if (question.getCorrectAnswer().equals(qdto.getAns())) {
                    totalScore += 1;
                    correct++;
                }
            }
        }
        return totalScore;
    }

    private int calculateScoreForSelections(int correctSelections, int totalCorrectOptions) {
        return Math.min(correctSelections, totalCorrectOptions);
    }

    @GetMapping("question/results")
    public String showResults(Model model, @AuthenticationPrincipal UserDetails currentUser)
    {
        List<AttemptedQuiz> list = attemptedQuizService.getUserSubmissions(currentUser.getUsername());
        Map<Integer,String> mp = new HashMap<>();
        for(AttemptedQuiz attemptedQuiz : list)
        {
            int id =attemptedQuiz.getQuizID();
            mp.put( id , quizService.getQuiz(id).getCategoryName());
        }
        model.addAttribute("quizAttempts",list);
        model.addAttribute("nameMap",mp);
        return "previousScore";
    }

}