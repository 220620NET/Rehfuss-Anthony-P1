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
      

    public User GetUser(string name)
    {
      return _repo.GetUser(name);
    }  

    public User AddUser(User user)
    {
      return _repo.AddUser(user);
    }

    public User Login(string name, string password)
    {
      return _repo.Login(name, password);
    }

    
}

