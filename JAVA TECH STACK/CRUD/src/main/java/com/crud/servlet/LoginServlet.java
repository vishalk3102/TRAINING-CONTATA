package com.crud.servlet;

import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import com.crud.Employee;
import com.crud.dao.EmployeeDao;
import com.crud.dao.UserDao;


@WebServlet("/login")
public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		try
		{
			String username=request.getParameter("username");
			String password=request.getParameter("password");
		
			UserDao dao=new UserDao();

			if(dao.authenticate(username, password))
			{
				HttpSession session=request.getSession();
				session.setAttribute("username",username);
				response.sendRedirect("list.jsp");
				
				EmployeeDao dao2 =new EmployeeDao();
				ArrayList<Employee> employees=(ArrayList<Employee>) dao2.getAllEmployee();
				
				if(employees !=null && !employees.isEmpty())
				{
					session.setAttribute("employees", employees);
				}
				else
				{
					String message="No Data to show";
					request.setAttribute("message", message);
				}
				RequestDispatcher rd=request.getRequestDispatcher("list.jsp");
				rd.include(request,response);
			}
			else
			{
				response.sendRedirect("login.jsp");
			}
		}
		catch(Exception e)
		{
			e.printStackTrace();
			response.sendRedirect("error.jsp");
		}
	}
}
