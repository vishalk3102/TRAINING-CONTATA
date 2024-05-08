<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Online Quiz Portal</title>
    <style>
        body {
            margin: 0;
            padding:0;
            font-family: Arial, sans-serif;
        }

        .navbar {
            overflow: hidden;
            display:flex;
            justify-content:space-around;
            align-items:center;
            background-color: #007bff
        }

        .navbar a {
            display: block;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 20px;
            text-decoration: none;
        }

        .navbar a:hover {
            cursor:pointer
        }

        .active {
            background-color: #04AA6D;
        }

        .logout-btn {
            background-color: #D63484;
            color: #fff;
            border: none;
            padding: 14px 20px;
            text-decoration: none;
            display: inline-block;
            margin: 8px 4px;
            cursor: pointer;
            border-radius: 5px;
            transition: background-color 0.3s;
        }

        .logout-btn:hover {
            background-color: #ab2345; /* Darker red on hover */
        }
    </style>
</head>
<body>

<div class="navbar">
    <div>
      <a >Quiz App</a>
    </div>
    <div>
        <a href="/home" >Home</a>
    </div>
    <div class="navbar-right">
        <a href="/logout" class="logout-btn">Logout</a>
    </div>
</div>


</body>
</html>
