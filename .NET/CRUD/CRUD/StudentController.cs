using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CRUD
{
    internal class StudentController
    {


        private static string connectionString= "Server=VISHALK\\SQLEXPRESS;Database=student;Trusted_Connection=True;TrustServerCertificate=True";



        public static void GetAllStudent()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM STUDENT";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id = {reader[0]} \n  Name = {reader[1]} \n Roll No = {reader[2]} \n Date of birth = {reader[3]} \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo student found ");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void GetStudentByRollNo(int rollNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM STUDENT WHERE rollNo=@RollNo";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@RollNo", rollNo);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id = {reader[0]} \nName = {reader[1]} \nRoll No = {reader[2]} \nDate of birth = {reader[3]} \n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo student found with the provided roll number.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void AddStudent(Student student) 
        {
            string name = student.name;
            int rollNo= student.rollNo;
            DateOnly dob = student.dob;

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString) )
                {
                    connection.Open();
                    string sql = "INSERT INTO STUDENT(name,rollno,dob) VALUES (@Name,@RollNo,@Dob)";
                    SqlCommand command= new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@RollNo", rollNo);
                    command.Parameters.AddWithValue("@Dob", dob);

                    int rowAffected=command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("\nData inserted Succesfully\n\n");
                    }
                }
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e.ToString());
            }
        }
        public static void UpdateStudent(int rNo,Student student,int option)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = " UPDATE STUDENT  SET ";
                    SqlCommand command = new SqlCommand(sql, connection);

                    switch(option)
                    {
                        case 1:
                            sql += " name=@Name";
                            command.Parameters.AddWithValue("@Name", student.name);
                            break;

                        case 2:
                            sql += " rollNo=@RollNo";
                            command.Parameters.AddWithValue("@RollNo", student.rollNo);
                            break;

                        case 3:
                            sql += " dob=@Dob";
                            command.Parameters.AddWithValue("@Dob", student.dob);
                            break;
                        default:
                            Console.WriteLine("Wrong Input ");
                            return;
                    }

                    sql += " WHERE rollNo=@rNo";
                    command.Parameters.AddWithValue("@rNo", rNo);
                    command.CommandText = sql;

                    int rowAffected = command.ExecuteNonQuery();
                    if(rowAffected > 0)
                    {
                       Console.WriteLine("\nData Updated Succesfully\n\n");
                    }
                    else
                    {
                        Console.WriteLine("\n Failed to Update Data\n\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void DeleteStudent(int rollNo) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = " DELETE FROM STUDENT WHERE rollNo = @RollNo";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@RollNo", rollNo);

                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("\nData Deleted Succesfully\n\n");
                    }
                    else
                    {
                        Console.WriteLine("\n Failed to Delete Data\n\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}


