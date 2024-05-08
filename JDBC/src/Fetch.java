import java.sql.*;


public class Fetch {
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

            String fetchQuery="SELECT * FROM STUDENT";
            ResultSet rs= statement.executeQuery(fetchQuery);

            String userData="";
            while(rs.next())
            {
                userData=rs.getInt(1)+ " : "+ rs.getString(2);
                System.out.println(userData);
            }
            statement.close();
            connection.close();
        }
        catch(SQLException e)
        {
            e.printStackTrace();
        }

    }
}
