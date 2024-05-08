<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz Attempts</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 800px;
            margin: 5rem auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            color: #007bff;
            margin-top: 0;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th, td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }
        th {
            background-color: #007bff;
            color: #fff;
            font-weight: bold;
            text-transform: uppercase;
        }
        tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        tr:hover {
            background-color: #ddd;
        }
        .back-btn {
            text-align: center;
            margin-top: 20px;
        }
        .back-btn a {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }
        .back-btn a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <jsp:include page="navbar.jsp" />
    <div class="container">
        <h2>Quiz Attempts</h2>
        <table>
            <thead>
                <tr>
                    <th>Quiz Name</th>
                    <th>Score</th>
                    <th>Attempted</th>
                </tr>
            </thead>
           <tbody>
                <%
                Map<Integer,String > mp = (Map<Integer,String>) request.getAttribute("nameMap");
                for (com.quiz.model.AttemptedQuiz attempt : (List<com.quiz.model.AttemptedQuiz>)request.getAttribute("quizAttempts")) { %>
                    <tr>
                        <td><%= mp.get(attempt.getQuizID()) %></td>
                        <td><%= attempt.getScore() %></td>
                        <td><%= attempt.getAttemptedAt() %></td>
                    </tr>
                <% } %>
            </tbody>
        </table>
        <div class="back-btn">
            <a href="/home">Back to Home</a>
        </div>
    </div>
</body>
</html>
