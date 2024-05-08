<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.List" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz Topics</title>
    <style><%@include file="../../css/style.css"%></style>
     <style>

        .quiz-topic{
            border: 1px solid #ddd;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 5px;
            cursor: pointer;
        }

        .quiz-topic:hover {
            background-color: #f0f0f0;
        }
    </style>
</head>
<body>
	<jsp:include page="navbar.jsp" />
    <div class="container">
        <h2>Quiz Topics</h2>
        <% 
        List<com.online.quiz.model.QuizTopic> quizTopics = (List<com.online.quiz.model.QuizTopic>) request.getAttribute("quizTopics");
        for (com.online.quiz.model.QuizTopic quizTopic : quizTopics) { %>
            <div class="quiz-topic" onclick="redirectToQuiz('<%= quizTopic.getId() %>')">
                <%= quizTopic.getTopicName() %>
            </div>
        <% } %>
    </div>

    <script>
        function redirectToQuiz(topicId) {
            window.location.href = "question/" + topicId;
        }
    </script>
</body>
</html>
