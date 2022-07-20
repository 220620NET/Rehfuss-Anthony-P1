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

     



      public List<Ticket> GetTicketsByStatus(string status)
      {
        List<Ticket> tickets = new List<Ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();
        
          SqlCommand cmd = new SqlCommand("Select * from Pro1.Ticket4 where status = @status", conn);

          cmd.Parameters.AddWithValue("@status", status);



     //   SqlCommand cmd = new SqlCommand("Select * from Pro1.Ticket4 where status = @status",conn);// SELECT  * from Pro1.Ticket4;
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
      // throw new NotImplementedException();
      SqlConnection conn = _connectionFactory.GetConnection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("Select * from Pro1.Ticket4 where ticket_Id = @id", conn);

          cmd.Parameters.AddWithValue("@id", id);

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


       public Ticket GetTicketByAuthor(string name)
     {
      // throw new NotImplementedException();
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
          throw new RecordNotFoundException("Could not find the ticket with that author");
      
     }

       public Ticket GetByStatus(string status)
     {
      // throw new NotImplementedException();
      SqlConnection conn = _connectionFactory.GetConnection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("Select * from Pro1.Ticket4 where status = @status", conn);

          cmd.Parameters.AddWithValue("@status", status);
        

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
          throw new RecordNotFoundException("Could not find the ticket with that status");
      
     }

     public Ticket AddTicket(Ticket newTicketToRegister)
     {
           DataSet ticketSet = new DataSet();

          SqlDataAdapter ticketAddapter = new SqlDataAdapter("SELECT  * from Pro1.Ticket4",
          _connectionFactory.GetConnection());

          ticketAddapter.Fill(ticketSet, "TicketTable");


          DataTable? ticketTable = ticketSet.Tables["TicketTable"];

          if(ticketTable != null)
          {
            DataRow newTicket = ticketTable.NewRow();
            newTicket["ticket_Id"] = newTicketToRegister.Id;
            newTicket["author_fk"] = newTicketToRegister.Author;
            newTicket["resolver_fk"] = newTicketToRegister.Resolover;
            newTicket["description"] = newTicketToRegister.Description;
            newTicket["status"] = newTicketToRegister.Status;
            newTicket["amount"] = newTicketToRegister.Amount;

            ticketTable.Rows.Add(newTicket);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ticketAddapter);
            SqlCommand insertCommand = commandBuilder.GetInsertCommand();

            ticketAddapter.InsertCommand = insertCommand;

            ticketAddapter.Update(ticketTable);

          }

          return newTicketToRegister;

     }


        public Ticket UpDateTicket(int Id, string status)
     {
            
           
             DataSet ticketSet = new DataSet();

            string sqlUpdateQuery = "UPDATE Pro1.Ticket4 SET status = @status WHERE ticket_Id = @Id;";
            SqlConnection conn = _connectionFactory.GetConnection();
          conn.Open();

           SqlDataAdapter adapter = new SqlDataAdapter();

          SqlCommand cmd = new SqlCommand(sqlUpdateQuery, conn);
          
          cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
          cmd.Parameters.Add("@status",SqlDbType.VarChar, 10).Value=status;
          
          adapter.UpdateCommand = cmd;

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
       //  throw new RecordNotFoundException("Could not find the ticket with that author");
          reader.Close();
          conn.Close();
      return new Ticket();
        
          
         
        
        
      
     }
    

}