

// See https://aka.ms/new-console-template for more information

using Models;
using Repository;
// namespace UI;
// Console.WriteLine("Hi project one!");

TicketReimbursementRepository postTickets = new TicketReimbursementRepository();

List<Ticket> tickets = postTickets.GetAllTickets();

foreach(Ticket i in tickets)
{
  Console.WriteLine(i);
}

Console.WriteLine("HI");

