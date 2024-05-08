package com.crud.servlet;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

import com.crud.Employee;
import com.crud.dao.EmployeeDao;

//@WebServlet("/list")
public class ListServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
   
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
	System.out.println("ListServlet - doGet method invoked");	
	EmployeeDao dao =new EmployeeDao();
	
		try {
			List<Employee> employees=dao.getAllEmployee();
			
			
			for(Employee emp:employees)
			{
				System.out.println(emp.getName());
			}
			if(employees !=null && !employees.isEmpty())
			{
				request.setAttribute("employees", employees);
			}
			else
			{
				String message="No Data to show";
				request.setAttribute("message", message);
			}
			request.getRequestDispatcher("list.jsp").forward(request,response);
			
		}catch(Exception e)
		{
			 e.printStackTrace();
			 request.setAttribute("errorMessage", "An unexpected error occurred");
	         request.getRequestDispatcher("error.jsp").forward(request, response);
		}	
	}

}
