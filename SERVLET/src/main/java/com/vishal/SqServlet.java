package com.vishal;




import java.io.IOException;

import java.io.PrintWriter;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.Cookie;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;


@WebServlet("/square")
public class SqServlet extends HttpServlet {
	 public void doGet(HttpServletRequest  req,HttpServletResponse res) throws IOException
	 {
		
		 
//		 sending value using requestDispatcher 
//		 int k=(int)req.getAttribute("k");
		 
		 
		 //sending value using sendredirect 
//		 int k=Integer.parseInt(req.getParameter("k"));		
		 
		 
//		 USING SESSION
//		 HttpSession session =req.getSession();
//		 int  k=(int)session.getAttribute("k");
//		   System.out.println("k----->"+k);
//		 k=k*k;
//
//	     PrintWriter out =res.getWriter();
//		 out.println("Result :"+k);
		 
		 
		 
//		 USING COOKIE
		 int k=0;
		 Cookie cookies[]=req.getCookies();
		 for(Cookie c:cookies)
		 {
			 if(c.getName().equals("k"))
			 {
				 k=Integer.parseInt(c.getValue());
			 }
		 }
		 
		 k=k*k;

	     PrintWriter out =res.getWriter();
		 out.println("Result :"+k);
	 }
}
