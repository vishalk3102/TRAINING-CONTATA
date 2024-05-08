<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %> 
<%@ page import="com.crud.*" %>  
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>


<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
  <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0px;
        }
        table, th, td {
            border: 1px solid #ddd;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
        }
        .btn {
            padding: 10px 12px;
            cursor: pointer;
            background-color: #4caf50;
            color: #fff;
            border: none;
            border-radius: 5px;
            margin-right: 10px;
            text-decoration:none;
        }
        .btn.add {
            background-color: #2196f3;
        }
        .btn.logout {
            background-color: #f44336;
        }
        .action-col
        {
         display :flex
        }
        h1
        {
          text-transform:"Uppercase";
        }
    </style>
<body>
<%
	if(session.getAttribute("username")==null)
		response.sendRedirect("login.jsp");
%>
 <div class="container">
        <h1>List of Employees</h1>
        <div>
            <a href="add.jsp" class="btn add">Add Employee</a>
            <a href="logout" class="btn logout">Logout</a>
        </div>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Department</th>
                    <th>Salary</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
             <% 
                ArrayList<Employee> employees = (ArrayList<Employee>)session.getAttribute("employees");
             if (employees != null && !employees.isEmpty()) 
             {
                for (Employee emp : employees) 
                {
             %>
             <tr>
                    <td><%= emp.getEmpId() %></td>
                    <td><%= emp.getName() %></td>
                    <td><%= emp.getDepartment() %></td>
                    <td><%= emp.getSalary() %></td>
                    <td class="action-col">
                  	    <form action="update" method="get">
						    <input type="hidden" name="id" value="<%= emp.getEmpId() %>">
						    <button type="submit" class="btn edit">Edit</button>
						</form>
                        <form action="delete" method="get">
						    <input type="hidden" name="id" value="<%= emp.getEmpId() %>">
						    <button type="submit" class="btn delete">Delete</button>
						</form>
                    </td>
             </tr>
            <% 
                 }
              } 
             else {      
             %>
             	<tr>
                    <td colspan="4">No employees found</td>
                </tr>
            <% 
              }
            %>
            </tbody>
        </table>
    </div>
</body>
</html>