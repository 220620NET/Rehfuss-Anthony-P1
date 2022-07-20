using Models;
using DataAccess;
using CustomExceptions;
namespace Services;

public class TicketService
{
    private readonly ITicketRepository _repo;

    public TicketService(ITicketRepository repo)
    {
      _repo = repo;
    }

    public List<Ticket> GetTickets()  // All tickets
    {
      return _repo.GetTickets();
    }

    public Ticket getTicketId(int id)
    {
        return _repo.GetTicket(id);
    }

    public Ticket getTicketByAuthor(string name)
    {
      return _repo.GetTicketByAuthor(name);
    }

    public Ticket getTicketByStatus(string status)
    {
      return _repo.GetByStatus(status);
    }

    public Ticket AddTicket(Ticket newTicket)
    {
      return _repo.AddTicket(newTicket);
    }

    public Ticket UpDateTicket(int id, string status)
    {
      return _repo.UpDateTicket(id, status);
    }

    

      
}
