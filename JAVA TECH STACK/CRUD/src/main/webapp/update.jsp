<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@ page import="com.crud.Employee" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Edit </title>
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
    <form action="update" method="post">
        <h2>Update Details</h2>
         <% 
         	Employee employee = (Employee)request.getAttribute("employee");
     	    if (employee != null) {
         %>
       
        <label for="empid">Employee ID:</label>
        <input type="text" id="empid" name="empid" value="<%= employee.getEmpId() %>" readonly>
        <label for="name">Name</label>
        <input type="text" id="name" name="name"  value="<%= employee.getName() %>" required>
        <label for="department">Department</label>
        <input type="text" id="department" name="department" value="<%= employee.getDepartment() %>" required>
        <label for="salary">Salary</label>
        <input type="number" id="salary" name="salary" value="<%= employee.getSalary() %>" required>
        <input type="submit" value="Update">
         <% 
         	} 
     	    else { 
     	 %>
        <p>Employee not found</p>
        <% } %>
    </form>
</body>
</html>
