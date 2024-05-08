import java.sql.*;

class Student2
{
    int id;
    String name;
}
class StudentDAO2{
    Connection con=null;

    public void connect() throws SQLException, ClassNotFoundException {
        String url = "jdbc:mysql://localhost:3306/students";
        String username = "root";
        String password = "12345";
        Class.forName("com.mysql.cj.jdbc.Driver");
        con=DriverManager.getConnection(url,username,password);
    }
    public Student getStudent(int id) throws ClassNotFoundException, SQLException {
        Student s=new Student();
        s.id=id;
        String query="Select * from student where id="+id;
        Statement st=con.createStatement();
        ResultSet rs=st.executeQuery(query);
        rs.next();
        s.name= rs.getString(2);
        return s;
    }

    public void addStudent(Student s) throws SQLException {
        String query="INSERT INTO STUDENT VALUES(?,?)";
        PreparedStatement st=con.prepareStatement(query);
        st.setInt(1,s.id);
        st.setString(2,s.name);
        int count= st.executeUpdate();
        System.out.println(count + "row affected");
    }
}
public class JDBCDAO {
    public static void main(String[] args) throws SQLException, ClassNotFoundException {
        StudentDAO2 DAO=new StudentDAO2();

        Student s=new Student();
        s.id=4;
        s.name="Shrey";
        DAO.connect();
        DAO.addStudent(s);
        System.out.println("\n\n");
        Student s2=DAO.getStudent(s.id);
        System.out.println(s2.name);
    }
}
