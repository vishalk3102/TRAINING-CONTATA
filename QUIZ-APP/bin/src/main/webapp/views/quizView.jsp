<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
 <%@ page import="java.util.List" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz</title>
    <style><%@include file="../../css/style.css"%></style>
    <style>
    	h2{
    	color:#fff;
    	}
    	form{
    		max-width:800px;
    	}
        p {
            margin: 10px 0;
        }
        input[type="checkbox"],
        input[type="radio"] {
            margin-right: 5px;
        }
        input[type="submit"] {
            display: block;
            width: 100%;
            margin-top: 10px;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            font-size:16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        input[type="submit"]:hover
        {
        	background-color:#5D9C59;
        }
	</style>
</head>
<body>
    <h2>Quiz Timer</h2>
    <div id="timer"></div>
    <h2>Quiz</h2>
    <form id="quizForm" class="container" action="/question/submitQuiz" method="post">
        <%-- Assume questions is a List<Question> attribute --%>
        <% List<com.online.quiz.model.Question> questions = (List<com.online.quiz.model.Question>) request.getAttribute("questions");
            for (com.online.quiz.model.Question question : questions) {
        %>
        <p><%= question.getQuestionText() %></p>
        <% if (question.isMultichoice()) { %>
            <%-- For multi-choice questions, use checkboxes --%>
            <input type="hidden" name="questionId" value="<%= question.getId() %>">
            <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption1() %>"> <%= question.getOption1() %><br>
            <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption2() %>"> <%= question.getOption2() %><br>
            <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption3() %>"> <%= question.getOption3() %><br>
            <input type="checkbox" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption4() %>"> <%= question.getOption4() %><br>
        <% } else { %>
            <%-- For single-choice questions, use radio buttons --%>
            <input type="hidden" name="questionId" value="<%= question.getId() %>">
            <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption1() %>"> <%= question.getOption1() %><br>
            <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption2() %>"> <%= question.getOption2() %><br>
            <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption3() %>"> <%= question.getOption3() %><br>
            <input type="radio" name="selectedOptions<%= question.getId() %>" value="<%= question.getOption4() %>"> <%= question.getOption4() %><br>
        <% }
            }
        %>
        <input type="hidden" name="quizId" value="${quizId}">
        <input type="hidden" name="username" value="${userId }"> 
        <input type="submit" value="Submit">
    </form>
   <script>
   document.addEventListener('DOMContentLoaded', function() {
        // Set the countdown time to 30 minutes (in milliseconds)
        const countdownTime = 30 * 60 * 1000; // 30 minutes * 60 seconds * 1000 milliseconds

        

        // Function to update the timer display
        function updateTimerDisplay(remainingTime) {
            const minutes = Math.floor(remainingTime / 60000);
            const seconds = Math.floor((remainingTime % 60000) / 1000); // Fixed
            console.log("Minutes:", minutes);
            console.log("Seconds:", seconds);
            document.getElementById('timer').innerHTML = 'Time remaining: ' + minutes + ':' + (seconds < 10 ? '0' : '') + seconds;
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
