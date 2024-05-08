<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.List" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            color: #333;
        }
        .main-div
        {
            margin:2rem 0;
        }
        .container {
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            color: #007bff;
            margin-top: 0;
        }
        form {
            margin-top: 20px;
        }
        p {
            margin-bottom: 10px;
            font-size: 18px;
        }
        input[type="checkbox"],
        input[type="radio"] {
            margin-right: 5px;
        }
        input[type="submit"] {
            display: block;
            width: 100%;
            margin-top: 20px;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #0056b3;
        }
        .timer-box
        {
            display:flex;
            justify-content:center;

        }
        #timer {
          font-size: 18px;
          color: #fff;
          height: 50px;
          width: 150px;
          padding: 5px;
          display: flex;
          justify-content: center;
          align-items: center;
          border-radius:6px;
          background-color:#007bff;
        }
    </style>
</head>
<body>
    <%@include file="navbar.jsp"%>
    <div class="main-div">
         <div class="timer-box">
              <div id="timer"></div>
         </div>
        <form id="quizForm" class="container" action="/question/submitQuiz" method="post">
            <h2>Questions</h2>
            <% List<com.quiz.model.Question> questions = (List<com.quiz.model.Question>) request.getAttribute("questions");
                for (com.quiz.model.Question question : questions) { %>
                <p><%= question.getQuestionText() %></p>
                <% if (question.isMultichoice()) { %>
                    <input type="hidden" name="questionId" value="<%= question.getId() %>">
                    <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption1() %>"> <%= question.getOption1() %><br>
                    <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption2() %>"> <%= question.getOption2() %><br>
                    <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption3() %>"> <%= question.getOption3() %><br>
                    <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption4() %>"> <%= question.getOption4() %><br>
                <% } else { %>
                    <input type="hidden" name="questionId" value="<%= question.getId() %>">
                    <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption1() %>"> <%= question.getOption1() %><br>
                    <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption2() %>"> <%= question.getOption2() %><br>
                    <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption3() %>"> <%= question.getOption3() %><br>
                    <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption4() %>"> <%= question.getOption4() %><br>
                <% }
                } %>
            <input type="hidden" name="quizId" value="${quizId}">
            <input type="hidden" name="username" value="${userId }">
            <input type="submit" value="Submit">
        </form>
    </div>


    <script>
        document.addEventListener('DOMContentLoaded', function() {
            const countdownTime = 10 * 60 * 1000;

            // Function to update the timer display
            function updateTimerDisplay(remainingTime) {
                const minutes = Math.floor(remainingTime / 60000);
                const seconds = Math.floor((remainingTime % 60000) / 1000);
                document.getElementById('timer').innerHTML = 'Timer : ' + minutes + ':' + (seconds < 10 ? '0' : '') + seconds;
            }

            // Function to handle the timer expiration
            function timerExpired() {
                alert('Time is up! Submitting the quiz.');
                document.getElementById('quizForm').submit(); // Submit the form
            }

            // Start the countdown timer
            const startTime = Date.now();
            const timerInterval = setInterval(() => {
                const elapsedTime = Date.now() - startTime;
                const remainingTime = countdownTime - elapsedTime;
                if (remainingTime <= 0) {
                    clearInterval(timerInterval);
                    timerExpired();
                } else {
                    updateTimerDisplay(remainingTime);
                }
            }, 1000);
        });
    </script>
</body>
</html>
