<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<!DOCTYPE html>
<html>
<head>
    <title>Quiz Attempts</title>
    <style><%@include file="../../css/style.css"%></style>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th, td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #f2f2f2;
            text-align:left;
        }
        tbody tr:nth-child(odd) {
    		background-color: #74E291;
		}
		tbody tr:nth-child(even){
		    background-color: #C5EBAA;
		}
        tbody tr:hover {
            background-color: #f9f9f9;
        }
       </style>
</head>
<body>
	<jsp:include page="navbar.jsp" />
    <div class="container">
        <h2>Quiz Attempts</h2>
        <table class="attempt-table">
            <thead>
                <tr>
                    <th>Quiz Name</th>
                    <th>Score</th>
                    <th>Attempted At</th>
                </tr>
            </thead>
            <tbody>
                <% 
                Map<Integer,String > mp = (Map<Integer,String>) request.getAttribute("nameMap");
                for (com.online.quiz.model.QuizAttempts attempt : (List<com.online.quiz.model.QuizAttempts>)request.getAttribute("quizAttempts")) { %>
                    <tr>
                        <td><%= mp.get(attempt.getQuizID()) %></td>
                        <td><%= attempt.getScore() %></td>
                        <td><%= attempt.getAttemptedAt() %></td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</body>
</html>
