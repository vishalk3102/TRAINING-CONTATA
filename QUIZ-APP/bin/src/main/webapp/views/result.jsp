<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <title>Quiz Score</title>
    <style><%@include file="../../css/style.css"%></style>
    <style>
        .score-info {
            margin-bottom: 20px;
        }
        .score-info p {
            margin: 5px 0;
        }
        .back-btn {
            display: block;
            width: 100%;
            padding: 10px;
            margin-top: 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            text-align: center;
            text-decoration: none;
        }
    </style>
</head>
<body>
	<jsp:include page="navbar.jsp" />
    <div class="container">
        <h2>Quiz Score</h2>
        <div class="score-info">
            <p>Hey <%= request.getAttribute("name") %>,</p>
            <p>Your Score: <%= request.getAttribute("score") %></p>
            <p>Correct Answers: <%= request.getAttribute("correctAnswers") %></p>
            <p>Incorrect or unattempted Answers: <%= request.getAttribute("incorrectAnswers") %></p>
        </div>
        <a href="/question/results" class="back-btn">go to all previous records</a>
    </div>
</body>
</html>
