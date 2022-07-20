using Models;

namespace DataAccess;

public interface IUserRepository
{
  List<User> GetAllUsers();

  // User GetUser(string name, string role, string password);
  User GetUser(string name);

  User AddUser(User newUserToRegister);

  User Login(string name, string password);


}