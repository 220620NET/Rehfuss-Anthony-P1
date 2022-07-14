using Models;
using Microsoft.Data.SqlClient;

public class ConnectionFactory
{
   private static ConnectionFactory? _instance;
   private readonly static string _connectionString = File.ReadAllText("../DataAccess/connectionString.txt");

   private ConnectionFactory() {}
   // getter for the one and only instance of connection factory
   public static ConnectionFactory GetInstance()
   {
         // first check if the instance already exists
         // if not, create a new one and assign it to our private field
         if(_instance == null)
         {
          _instance = new ConnectionFactory();
         }
         // if it already exists, just give that instance
         return _instance;
   }

   public SqlConnection GetConnection()
    {
      return new SqlConnection(_connectionString);
    }
   

}