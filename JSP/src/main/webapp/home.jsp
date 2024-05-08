 
 
 <%-- @page directive --%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	  <h1>Hello world</h1>
	  <%
	   		out.println(10+8);
	  %>
	  
	   <%--
		 	  @Include  directive 
			  <%@ include file="filename" %>
			  <%@ include file="header.jsp" %>  
	   --%>
	   
	   <%--   
		      @Taglib  
	 		  <%@ taglib uri="uri" prefix="fx" %>
	 	 	  <fx:vishal>  
	   ----%>  
	   <!-- it shows this tag belong to fx  -->
</body>
</html>