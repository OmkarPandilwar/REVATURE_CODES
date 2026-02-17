using MySql.Data.MySqlClient;



class Program
{
    static void Main()
    {
        string connStr = "server=localhost;database=college_db;user=root;password=root;";
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        Console.WriteLine("Connected Successfully");

   //    string query = "SELECT * FROM students where age>22";
    //  MySqlCommand sqlCommand =new MySqlCommand(query,conn);

    //   MySqlDataReader reader =sqlCommand.ExecuteReader();






    //     while (reader.Read())
    //     {
    //        int id = reader.GetInt32(0);
    // string firstName = reader.GetString(1);
    // string lastName = reader.GetString(2);
    // int age = reader.GetInt32(3);
    // string email = reader.GetString(4);
    // string course = reader.GetString(5);

    //  Console.WriteLine($"{id} - {firstName} {lastName} - {age} - {email} - {course}");
    // //      //   // int id = reader.GetInt32(0);
    //         // string firstName = reader.GetString(1);
    //        // string lastName = reader.GetString(2);

            
    // //Console.WriteLine($"{id} - {firstName} {lastName}");
    //     }

       // 
    //    reader.Close();
        
         ExecuteScalarExample(conn);
         ExecuteNonQuery(conn);
          
    }


   static void ExecuteNonQuery(MySqlConnection connection)
    {
        var query = "INSERT INTO studen;ts (FirstName, LastName, Age) VALUES ('Ramesh', 'kumar', 30)";

        using var command = new MySqlCommand(query, connection);

        

    //    Console.WriteLine($"Rows affected: {rowsAffected}");
       


    }
 static void ExecuteScalarExample(MySqlConnection connection)
{
    var query = "SELECT COUNT(*) FROM students";

    using var command = new MySqlCommand(query, connection);

    var result = command.ExecuteScalar();

    Console.WriteLine($"Total Students: {result}");
}






}
