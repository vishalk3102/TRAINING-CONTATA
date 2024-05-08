  package com.crud.servlet;

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

@WebServlet("/delete")
public class DeleteServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		try
		{
			int empId=Integer.parseInt(request.getParameter("id"));
			EmployeeDao dao=new EmployeeDao();
			dao.deleteEmployee(empId);
			ArrayList<Employee> updatedEmployees = (ArrayList<Employee>) dao.getAllEmployee();

	        HttpSession session = request.getSession();
	        session.setAttribute("employees", updatedEmployees);
			
			response.sendRedirect("list.jsp");
		}
		catch(Exception e)
		{
			e.printStackTrace();
			response.sendRedirect("error.jsp");
		}
		
		
	}

}
