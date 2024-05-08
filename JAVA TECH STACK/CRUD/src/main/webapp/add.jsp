<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Add Employee</title>
</head>
<style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        form {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }
        input[type="text"],
        input[type="number"],
        input[type="submit"] {
            width: 100%;
            padding: 10px;
            margin: 5px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }
        input[type="submit"] {
            background-color: #4caf50;
            color: #fff;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
<body>
<%
	if(session.getAttribute("username")==null)
		response.sendRedirect("login.jsp");
%>
     <form action="add" method="post">
        <h2>Add Details</h2>
        <label for="empid">Employee ID</label>
        <input type="text" id="id" name="empid" required>
        <label for="name">Name</label>
        <input type="text" id="name" name="name" required>
        <label for="department">Department</label>
        <input type="text" id="department" name="department" required>
        <label for="salary">Salary</label>
        <input type="number" id="salary" name="salary" required>
        <input type="submit" value="Submit">
    </form>
</body>
</html>
