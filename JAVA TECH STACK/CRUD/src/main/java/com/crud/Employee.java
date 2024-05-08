package com.crud;

public class  Employee
{
	int emp_id;
	String name;
	String department;
	double salary;
	public int getEmpId() {
		return emp_id;
	}
	public String getName() {
		return name;
	}
	public String getDepartment() {
		return department;
	}
	public double getSalary() {
		return salary;
	}
	public void setEmpID(int emp_id) {
		this.emp_id=emp_id;
	}
	public void setName(String name) {
		this.name=name;
	}
	public void setDepartment(String department) {
		this.department=department;
	}
	public void setSalary(double salary) {
		this.salary=salary;
	}
}