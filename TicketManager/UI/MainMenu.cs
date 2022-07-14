using Models;
using Services;
using System.Text.Json;
using CustomExceptions;

namespace UI;

public class MainMenu
{
    private readonly AuthServices _auth;
    public MainMenu (AuthServices auth)
    {
      _auth = auth;
    }

    public void Start()
    {
      Console.WriteLine("Welcome to Ticket Remuneration");
      Console.WriteLine("A Place Employees can be compensated in dollars and cents");
        while(true)
        {
          Console.WriteLine("Registered already? [y/n/exit]");
          char userInput = Console.ReadLine().ToLower()[0];

          switch(userInput)
          {
            case 'y':
            //Send them to log in
            break;

            case 'n':
                RegisterNewUser();
            break;

            case 'e': 
               Console.WriteLine("See You later");
               Environment.Exit(0);
            break;

            default:
               Console.WriteLine("Say What?");
              break;
          }

        }

    }

    private void RegisterNewUser()
    {
      Console.WriteLine("Register a new user");
      Console.WriteLine("What's your name");
      string username = Console.ReadLine();
      Console.WriteLine("Are you a manager or employee?");
      string role = Console.ReadLine();
      Console.WriteLine("Enter a good password");
      string password = Console.ReadLine();

      // User newUser = new User();
      // newUser.Role = role;
      // newUser.UserName = username;
      // newUser.Password = password;
      User registeringUser = new User{
        UserName = username,
        Password = password,
        Role = role
      };

      try
      {
        User user = _auth.Register(registeringUser);
        Console.WriteLine("Registered successfully");
        Console.WriteLine(user.UserName + ": " + user.Role);

      }
      catch(JsonException ex)
      {
        Console.WriteLine("Sorry, something went wrong with our database, try again" );
      }
      catch(DuplicateRecordException ex)
      {
           Console.WriteLine("Sorry, that name is already taken");
      }

     }
     // UI's work is done!
    
}