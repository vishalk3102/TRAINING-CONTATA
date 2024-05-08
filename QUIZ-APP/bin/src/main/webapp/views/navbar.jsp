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
            background-color: #333;
        }

        .navbar a {
            float: left;
            display: block;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 20px;
            text-decoration: none;
        }

        .navbar a:hover {
            background-color: #ddd;
            color: black;
        }

        .active {
            background-color: #04AA6D;
        }
		.active-link{
			color:#D63484;
		}
        .navbar-right {
            float: right;
        }

        @media screen and (max-width: 600px) {
            .navbar a {
                float: none;
                display: block;
                text-align: left;
            }
            .navbar-right {
                float: none;
            }
        }
    </style>
</head>
<body>

<div class="navbar">
    <a class="active">Online Quiz Portal</a>
    <a href="/home" >Home</a>
    <a href="/question/results">Previous Attempts</a>
    <div class="navbar-right">
        <a >Hello </a>|
        <a href="/logout">Logout</a>
    </div>
</div>


</body>
</html>
