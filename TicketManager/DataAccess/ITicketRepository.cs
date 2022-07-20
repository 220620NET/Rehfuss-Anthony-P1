using Models;
using Microsoft.Data.SqlClient;
using CustomExceptions;
using System.Data;

namespace DataAccess;

public interface ITicketRepository
{
  List<Ticket> GetTickets();

  Ticket GetTicket(string name);  

  Ticket GetTicket(int id); // ticket_Id in database

  Ticket GetTicketByAuthor(string name);

  Ticket AddTicket(Ticket newTicketToRegister);

  Ticket GetByStatus(string status);

  Ticket UpDateTicket(int id, string decision);



}