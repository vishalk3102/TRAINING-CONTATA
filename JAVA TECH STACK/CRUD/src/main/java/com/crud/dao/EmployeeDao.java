package com.crud.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.crud.Employee;


public class EmployeeDao {
	Connection con =null;
	private static  String url="jdbc:mysql://localhost:3306/employees";
	private static  String username="root";
	private static  String password="12345";	
	
	public EmployeeDao() {
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            con = DriverManager.getConnection(url, username, password);
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
	
	public List<Employee> getAllEmployee()
	{
		List<Employee> employees=new ArrayList<Employee>();
		try
		{
			 
			String sql ="select * from employees.employees";
			PreparedStatement st=con.prepareStatement(sql);
			ResultSet rs=st.executeQuery();
			while(rs.next())
			{
				Employee emp=new Employee();
				emp.setEmpID(rs.getInt("emp_id"));
				emp.setName(rs.getString("name"));
				emp.setDepartment(rs.getString("department"));
				emp.setSalary(rs.getDouble("salary"));	
				employees.add(emp);
			}
		}
		catch(SQLException e)
		{
			e.printStackTrace();
		}
		return employees;
	}
	
	public Employee getEmployeeById(int id)
	{
		Employee employee=null;
		try
		{
			String sql="select * from employees where emp_id=?";
			PreparedStatement st=con.prepareStatement(sql);
			st.setInt(1,id);
			ResultSet rs=st.executeQuery();
			
			if(rs.next())
			{
				String name=rs.getString("name");
				String department=rs.getString("department");
				double salary=rs.getDouble("salary");
			
				employee=new Employee();
				employee.setEmpID(id);
				employee.setName(name);
				employee.setDepartment(department);
				employee.setSalary(salary);	
			}
		}
		catch(SQLException e){
			e.printStackTrace();
		}
		return  employee;
	}
	
	public void addEmployee(Employee emp)
	{
		try
		{
			System.out.println("after connection ");
			String sql ="insert into employees values (?,?,?,?)";
			PreparedStatement st=con.prepareStatement(sql);
			st.setInt(1,emp.getEmpId() );
			st.setString(2,emp.getName() );
			st.setString(3,emp.getDepartment() );
			st.setDouble(4,emp.getSalary() );
			st.executeUpdate();
		}
		catch(SQLException e)
		{
			e.printStackTrace();
		}
	}
	
	public void updateEmployee(Employee emp)
	{
		try
		{
			String sql ="update employees.employees set name=?,department=?,salary=? where emp_id=?";
			PreparedStatement st=con.prepareStatement(sql);
			st.setString(1,emp.getName() );
			st.setString(2,emp.getDepartment() );
			st.setDouble(3,emp.getSalary() );
			st.setInt(4,emp.getEmpId() );
			st.executeUpdate();
		}
		catch(SQLException e)
		{
			e.printStackTrace();
		}
	}
	
	public void deleteEmployee(int id)
	{
		try
		{
			String sql ="delete from employees where emp_id =?";
			PreparedStatement st=con.prepareStatement(sql);
			st.setInt(1,id);
			st.executeUpdate();
		}
		catch(SQLException e)
		{
			e.printStackTrace();
		}
	}
}
