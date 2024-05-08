import java.sql.*;

public class PreparedStatmentInsert {
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
            int id=3;
            String name="sahil";
            String insertQuery="INSERT INTO STUDENT VALUES(?,?)";
            Connection connection = DriverManager.getConnection(url,username,password);
            PreparedStatement statement=connection.prepareStatement(insertQuery);

            statement.setInt(1,id);
            statement.setString(2,name);


            int count= statement.executeUpdate();
            System.out.println(count + "Count affected");

            statement.close();
            connection.close();
        }
        catch(SQLException e)
        {
            e.printStackTrace();
        }

    }
}
