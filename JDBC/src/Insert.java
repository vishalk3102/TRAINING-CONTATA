import java.sql.*;


public class Insert {
    public static void main(String[] args) {
        String url = "jdbc:mysql://localhost:3306/students";
        String username = "root";
        String password = "12345";

        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
        }
        catch(ClassNotFoundException e)
        {
            e.getMessage();
        }

        try{
            Connection connection = DriverManager.getConnection(url,username,password);
            Statement statement=connection.createStatement();
            String insertQuery="INSERT INTO STUDENT VALUES(2,'GEETANSH')";
            int count= statement.executeUpdate(insertQuery);

            System.out.println(count + "Count affected");
//            String userData;
//            while(rs.next())
//            {
//                userData=rs.getInt(1)+ " : "+ rs.getString(2);
//                System.out.println(userData);
//            }
            statement.close();
            connection.close();
        }
        catch(SQLException e)
        {
            e.printStackTrace();
        }

    }
}
