using Models;
using DataAccess;

namespace Services;

public class UserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
      _repo = repo;
    }

    public List<User> GetAllUsers()
    {
      return _repo.GetAllUsers();
    }
      
}

