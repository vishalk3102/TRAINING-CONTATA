import java.sql.*;

public class Create_DB {
    public static void main(String[] args) {
        // JDBC URL, username, and password of MySQL server
        String url = "jdbc:mysql://localhost:3306/students"; // Changed to "students" database
        String user = "root";
        String password = "12345";
        try {
            Class.forName("com.mysql.cj.jdbc.Driver"); // Load driver
        } catch (ClassNotFoundException e) {
            System.out.println(e.getMessage());
        }

        try {
            // Establishing a connection to MySQL database
            Connection connection = DriverManager.getConnection(url, user, password);

            // Creating a statement object to execute queries
            Statement statement = connection.createStatement();

            // SQL query to create a new table named "std" with fields "id" and "name"
            String createTableQuery = "CREATE TABLE std3 (id INT, name VARCHAR(30))";

            // Executing the SQL query to create the table
            statement.executeUpdate(createTableQuery);

            System.out.println("Table created successfully!");

            // Closing resources
            statement.close();
            connection.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
