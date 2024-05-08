package com.crud.servlet;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.util.ArrayList;

import com.crud.dao.EmployeeDao;
import com.crud.Employee;


@WebServlet("/add")
public class AddServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected  void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {		
		try
		{
			int  empid=Integer.parseInt(request.getParameter("empid"));
			String name =request.getParameter("name");
			String department =request.getParameter("department");
			Double salary =Double.parseDouble(request.getParameter("salary"));
			
			Employee emp=new Employee(); 
			emp.setEmpID(empid);
			emp.setName(name);
			emp.setDepartment(department);
			emp.setSalary(salary);
			
			EmployeeDao dao=new EmployeeDao();
			dao.addEmployee(emp);
			
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
