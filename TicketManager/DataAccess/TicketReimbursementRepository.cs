using Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Repository;

public class TicketReimbursementRepository
{
        string connectionString = "Server=tcp:anth.database.windows.net,1433;Initial Catalog=Anth;Persist Security Info=False;User ID=sqluser;Password=p4ssw0rd!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public List<Ticket> GetAllTickets()
    {
       List<Ticket> tickets = new List<Ticket>();

       string sql = "SELECT  * from Pro1.Ticket;";
         //datatype to reference the sql command you want to do to a specific connection
       SqlConnection connection = new SqlConnection(connectionString);

       SqlCommand command = new SqlCommand(sql, connection);
       try
       {
             connection.Open();
             SqlDataReader reader = command.ExecuteReader();
             while(reader.Read())
             {
              tickets.Add(new Ticket((int)reader[0],(string)reader[1],(string) reader[2],(string)reader[3],(string)reader[4],(decimal)reader[5]));
             }

             reader.Close();
             connection.Close();

       }
       catch (Exception e)
       {
        Console.WriteLine(e.Message);
       }

       return tickets;

    }

}