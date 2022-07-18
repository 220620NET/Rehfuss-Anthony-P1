using Models;
using DataAccess;

namespace Services;

public class TicketService
{
    private readonly ITicketRepository _repo;

    public TicketService(ITicketRepository repo)
    {
      _repo = repo;
    }

    public List<Ticket> GetTickets()
    {
      return _repo.GetTickets();
    }
      
}
