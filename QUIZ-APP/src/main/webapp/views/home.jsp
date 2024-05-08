<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
       .container {
           height: 300px;
           max-width: 600px;
           margin: 10rem auto;
           padding: 20px;
           background-color: #fff;
           border-radius: 10px;
           box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
           display: flex;
           justify-content: center;
           align-items: center;
           flex-direction: column;
       }
        h1 {
            text-align: center;
            margin-bottom: 30px;
        }
        .button-container {
            text-align: center;
        }
        .button {
            display: inline-block;
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 15px 30px;
            margin: 10px;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
            font-size: 18px;
        }
        .button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <jsp:include page="navbar.jsp" />
    <div class="container">
        <h1>Welcome ${user}</h1>
        <div class="button-container">
            <a href="/takequiz" class="button">Take Quiz</a>
            <a href="/question/results" class="button">Previous Scores</a>
        </div>
    </div>
</body>
</html>