using Models;
using System;
using Microsoft.Data.SqlClient;
using CustomExceptions;
using System.Data;

namespace DataAccess;




public class TicketReimbursementRepository : ITicketRepository
{
        
    

       private readonly ConnectionFactory _connectionFactory;
        
        public TicketReimbursementRepository(ConnectionFactory connectionFactory)
        {
          _connectionFactory = connectionFactory;
        }



      public List<Ticket> GetTickets()
      {
        List<Ticket> tickets = new List<Ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * from Pro1.Ticket4",conn);// SELECT  * from Pro1.Ticket4;
        SqlDataReader reader = cmd.ExecuteReader();
        

        while(reader.Read())
        {
          tickets.Add(new Ticket
          {
            Id = (int)reader["ticket_Id"],
            Author = (string)reader["author_fk"],
            Resolover = (string) reader["resolver_fk"],
            Description = (string)reader["description"],
            Status = (string)reader["status"],
            Amount = (decimal)reader["amount"]
           
            
          });
        
        }
          reader.Close();
          conn.Close();

          return tickets;
      }

     public Ticket GetTicket(string name)
     {
         // Ticket foundTicket;
          SqlConnection conn = _connectionFactory.GetConnection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("Select * from Pro1.Ticket4 where author_fk = @name", conn);

          cmd.Parameters.AddWithValue("@name", name);

          SqlDataReader reader = cmd.ExecuteReader();

          while(reader.Read())
          {
            return new Ticket
            {
            Id = (int)reader["ticket_Id"],
            Author = (string)reader["author_fk"],
            Resolover = (string) reader["resolver_fk"],
            Description = (string)reader["description"],
            Status = (string)reader["status"],
            Amount = (decimal)reader["amount"]
            };
          }
          throw new RecordNotFoundException("Could not find the ticket with that id");
     }

     public Ticket GetTicket(int id)
     {
      throw new NotImplementedException();
     }


     public Ticket AddTicket(Ticket newTicketToRegister)
     {
          DataSet ticketSet = new DataSet();

          SqlDataAdapter ticketAddapter = new SqlDataAdapter("Select * from Pro1.Ticket4",
          _connectionFactory.GetConnection());

          ticketAddapter.Fill(ticketSet, "ticketTable");


          DataTable? ticketTable = ticketSet.Tables["trainerTable"];

          if(ticketTable != null)
          {
            DataRow newTicket = ticketTable.NewRow();
            newTicket["ticket_Id"] = newTicketToRegister.Id;
            newTicket["author_fk"] = newTicketToRegister.Author;
            newTicket["resolver_fk"] = newTicketToRegister.Resolover;
            newTicket["description"] = newTicketToRegister.Description;
            newTicket["status"] = newTicketToRegister;
            newTicket["amount"] = newTicketToRegister;

            ticketTable.Rows.Add(newTicket);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ticketAddapter);
            SqlCommand insertCommand = commandBuilder.GetInsertCommand();

            ticketAddapter.InsertCommand = insertCommand;

            ticketAddapter.Update(ticketTable);

          }

          return newTicketToRegister;

     }


    

}