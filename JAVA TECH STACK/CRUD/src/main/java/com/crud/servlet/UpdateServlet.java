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

import com.crud.Employee;
import com.crud.dao.EmployeeDao;

@WebServlet("/update")
public class UpdateServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
    
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		 try {
	            int empId = Integer.parseInt(request.getParameter("id"));
	            EmployeeDao employeeDao = new EmployeeDao();
	            Employee employee = employeeDao.getEmployeeById(empId);

	            if (employee != null) {
	                request.setAttribute("employee", employee);
	                RequestDispatcher dispatcher = request.getRequestDispatcher("update.jsp");
	                dispatcher.forward(request, response);
	            } else {
	                response.sendRedirect("error.jsp");
	            }
	        } catch (NumberFormatException e) {
	        	e.printStackTrace();
	            response.sendRedirect("error.jsp");
	        }
	}
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {	
		try
		{
			int empId=Integer.parseInt(request.getParameter("empid"));
			String name =request.getParameter("name");
			String department =request.getParameter("department");
			Double salary =Double.parseDouble(request.getParameter("salary"));
			
			Employee emp=new Employee(); 
			emp.setEmpID(empId);
			emp.setName(name);
			emp.setDepartment(department);
			emp.setSalary(salary);
			
			EmployeeDao dao=new EmployeeDao();
			dao.updateEmployee(emp);
			
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
