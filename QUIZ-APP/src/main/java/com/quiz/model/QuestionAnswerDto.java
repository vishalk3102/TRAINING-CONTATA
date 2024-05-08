package com.quiz.model;

import java.util.List;


public class QuestionAnswerDto {
    private int questionId;
    private List<String> selectedOptions;
    public int getQuestionId() {
        return questionId;
    }
    public void setQuestionId(int questionId) {
        this.questionId = questionId;
    }
    public List<String> getSelectedOptions() {
        return selectedOptions;
    }
    public void setSelectedOptions(List<String> selectedOptions) {
        this.selectedOptions = selectedOptions;
    }
    public String getAns()
    {
        String ans=String.join(",", selectedOptions);
        return ans;
    }
    @Override
    public String toString() {
        return "QuestionAnswerDTO [questionId=" + questionId + ", selectedOptions=" + selectedOptions + "]";
    }



}