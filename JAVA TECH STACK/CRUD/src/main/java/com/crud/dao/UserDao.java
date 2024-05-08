package com.crud.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class UserDao 
{
	Connection con =null;
	private static  String url="jdbc:mysql://localhost:3306/employees";
	private static  String username="root";
	private static  String password="12345";	
	
	public UserDao() 
	{
		try {
			 Class.forName("com.mysql.cj.jdbc.Driver");
			 con=DriverManager.getConnection(url,username,password);
	        } catch (SQLException | ClassNotFoundException e) {
	           e.printStackTrace();
	        }
	}
	
	public boolean authenticate(String username,String password)
	{			  
		try {
			String sql="Select * from credentials where username=? and password=?";
			PreparedStatement st=con.prepareStatement(sql);
			st.setString(1, username);
			st.setString(2, password);
			ResultSet rs=st.executeQuery();
			if(rs.next())
			{
				return true;
			}
			System.out.println("Connection established");
			st.close();
	        con.close();
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
		return false;
	}
}