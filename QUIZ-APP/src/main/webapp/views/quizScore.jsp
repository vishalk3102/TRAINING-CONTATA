<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quiz Score Card</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            color: #333;
        }
        .container {
            max-width: 600px;
            margin: 5rem auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #007bff;
            margin-top: 0;
        }
        .score-info {
            margin-bottom: 30px;
        }
        .score-info p {
            font-size: 18px;
            margin: 10px 0;
        }
        .score-info p span {
            font-weight: bold;
        }
       .button-wrapper {
           text-align: center;
           width: 150px;
           height: 50px;
           display: flex;
           justify-content: center;
           align-items: center;
           background-color: #007bff;
           border-radius: 6px;

       }
       .button-wrapper a {
            text-decoration:none;
            color: #fff;
       }
       .button-wrapper:hover
       {
         cursor:pointer;
       }

    </style>
</head>
<body>
    <jsp:include page="navbar.jsp" />
    <div class="container">
        <h1>Quiz Score Card</h1>
        <div class="score-info">
            <p>${name} ,Congratulations on completing the quiz!</p>
            <br/>
            <br/>
            <p><span>Total Questions:</span> <span id="totalQuestions">10</span></p>
            <p><span>Correct Answers:</span> <span id="correctAnswers">${correctAnswers}</span></p>
            <p><span>Incorrect or unattempted Answers:</span> <span id="incorrectAnswers">${incorrectAnswers}</span></p>
            <p><span>Your Score:</span> <span id="score">${score}</span></p>
        </div>
        <div class="button-wrapper">
            <a href="/question/results">Previous Scores</a>
        </div>
    </div>
</body>
</html>