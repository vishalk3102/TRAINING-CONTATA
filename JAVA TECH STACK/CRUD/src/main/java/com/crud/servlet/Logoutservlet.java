package com.crud.servlet;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;


@WebServlet("/logout")
public class Logoutservlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

		try
		{
			HttpSession session=request.getSession();
			session.removeAttribute("username");
			session.invalidate();
			response.sendRedirect("login.jsp");
		}
		catch(Exception e)
		{
			e.printStackTrace();
			response.sendRedirect("error.jsp");
		}
	}
}

