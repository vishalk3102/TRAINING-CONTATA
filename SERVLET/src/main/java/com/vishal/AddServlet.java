package com.vishal;




import java.io.IOException;

import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import jakarta.servlet.http.*;


@WebServlet("/add")
public class AddServlet extends HttpServlet {

//	 public void service(HttpServletRequest  req,HttpServletResponse res) throws IOException
//	 {
//		 int i=Integer.parseInt(req.getParameter("num1"));
//		 int j=Integer.parseInt(req.getParameter("num2"));
//		 
//		 int k=i+j;
//		 
//		 PrintWriter out =res.getWriter();
//		 out.println("Result is  :"+k);
//		 
//	 }
	 
	 public void doGet(HttpServletRequest  req,HttpServletResponse res) throws IOException, ServletException
	 {
		 int i=Integer.parseInt(req.getParameter("num1"));
		 int j=Integer.parseInt(req.getParameter("num2"));
		 
		 int k=i+j;
		   System.out.println("k----->"+k);
		 
		   
		 //Request dispatcher 
//		 req.setAttribute("k", k);
//		 RequestDispatcher rd=req.getRequestDispatcher("square");
//		 rd.forward(req,res);
		 
//		 REDIRECT
//		 res.sendRedirect("square");
		 
		 // this technique comes under session management 
//		 res.sendRedirect("square?k="+k);  
		 
		 //SESSION MANAGEMENT 
//		 HttpSession session =req.getSession();
//		 session.setAttribute("k", k);
//		 res.sendRedirect("square?k="+k);  
  
		   
//		   USING COOKIES 
		   Cookie cookie =new Cookie("k",k+"");
		   res.addCookie(cookie);
		   res.sendRedirect("square");  
		   
		 
	 }
//	 public void doPost(HttpServletRequest  req,HttpServletResponse res) throws IOException
//	 {
//		 int i=Integer.parseInt(req.getParameter("num1"));
//		 int j=Integer.parseInt(req.getParameter("num2"));
//		 
//		 int k=i+j;
//		 
//		 PrintWriter out =res.getWriter();
//		 out.println("Result is  :"+k);
//		 
//	 }
}
