using Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Repository;

public class TicketReimbursementRepository
{
          private readonly ConnectionFactory _connectionFactory;
        
        public TicketReimbursementRepository(ConnectionFactory connectionFactory)
        {
          _connectionFactory = connectionFactory;
        }
    public List<Ticket> GetAllTickets()
    {
       List<Ticket> tickets = new List<Ticket>();

       string sql = "SELECT * from Pro1.Ticket4;";
         //datatype to reference the sql command you want to do to a specific connection
       SqlConnection connection = _connectionFactory.GetConnection();

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