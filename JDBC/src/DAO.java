import java.sql.*;



//DAO = DATA ACCESS OBJECT

class Student
{
    int id;
    String name;

}
class StudentDAO{
    public Student getStudent(int id) throws ClassNotFoundException, SQLException {
        Student s=new Student();
        s.id=id;

        String url = "jdbc:mysql://localhost:3306/students";
        String username = "root";
        String password = "12345";

        String query="Select * from student where id="+id;
        Class.forName("com.mysql.cj.jdbc.Driver");
        Connection con=DriverManager.getConnection(url,username,password);
        Statement st=con.createStatement();
        ResultSet rs=st.executeQuery(query);
        rs.next();
        String studentName=rs.getString(2);
        s.name=studentName;
        return s;

    }
}
public class DAO {
    public static void main(String[] args) throws SQLException, ClassNotFoundException {
      StudentDAO DAO=new StudentDAO();
      Student s=DAO.getStudent(2);
      System.out.println(s.name);
    }
}
