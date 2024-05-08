<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.List" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz Topics</title>
    <style>
       .container {
           height: 250px;
           max-width: 600px;
           margin: 6rem auto;
           padding: 20px;
           border: 1px solid #ddd;
           border-radius: 5px;
           background-color: #fff;
           display: flex;
           flex-direction: column;
           justify-content: center;
           align-items: center;
       }

        .quiz-topic {
            border: 1px solid #ddd;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 5px;
            cursor: pointer;
        }

        .quiz-topic:hover {
            background-color: #f0f0f0;
        }

        .select-container {
            margin-bottom: 20px;
            text-align: center;
        }

        .select-container select {
            padding: 10px;
            font-size: 16px;
            border-radius: 5px;
        }

        .start-quiz-btn {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .start-quiz-btn:hover {
            background-color: #0056b3;
        }
        h2
        {
          text-align:center;
        }
    </style>
</head>
<body>
<jsp:include page="navbar.jsp" />
<div class="container">
    <h2>Quiz Topics</h2>
    <div class="select-container">
        <select id="quizTopicSelect">
            <option value="">Select a quiz topic...</option>
            <%
                List<com.quiz.model.Category> quizTopics = (List<com.quiz.model.Category>) request.getAttribute("quizTopics");
                for (com.quiz.model.Category quizTopic : quizTopics) {
            %>
            <option value="<%= quizTopic.getId() %>"><%= quizTopic.getCategoryName() %></option>
            <% } %>
        </select>
    </div>
    <div style="text-align: center;">
        <button class="start-quiz-btn" onclick="startQuiz()">Take Quiz</button>
    </div>
</div>

<script>
    function startQuiz() {
        var selectedTopic = document.getElementById("quizTopicSelect").value;
        if (selectedTopic) {
            window.location.href = "question/" + selectedTopic;
        } else {
            alert("Please select a quiz topic.");
        }
    }
</script>
</body>
</html>
