using Models;
using System.Text.Json;
using DataAccess;
using CustomExceptions;

namespace Services;

public class AuthServices
{
  private readonly IUserRepository _repo;
   // dependency injection
  public AuthServices(IUserRepository repository)
  {
    _repo = repository;
  }

  public User Register(User newUser)
  {
    try{
      _repo.GetUser(newUser.UserName);
      throw new DuplicateRecordException();
    }
    catch(RecordNotFoundException)
    {
       //  Console.WriteLine("WE didn't find the record");
         return _repo.AddUser(newUser);
    }
  }

}