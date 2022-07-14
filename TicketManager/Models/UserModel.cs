 using CustomExceptions;
 namespace Models;



public class User
{
    public string Role {get; set;}
    public string Password {get; set;}
  //  public string UserName {get; set;}
    public User()
    {
      Role = "";
      Password = "";
    }

    public User(string UserName)
    {
        this.UserName = UserName;
        Role = "";
        Password = "";
    }
    
  //  public string UserName {get; set;}
    
    public User(string UserName,string Password, string Role )
    {
       this.UserName = UserName;
       this.Password = Password;
       this.Role = Role;
       
    }

    private string _userName;
    
    public string UserName
    {
      get 
      {
        return _userName;
      }
      // C# provides the value user is trying to gset this property with as a variable name "value" in the setter
      set
      {
        if(String.IsNullOrWhiteSpace(value))
        {
          throw new InputInvalidException("Name must not be empty");
        }
        else if(value.Length == 0 && value.Length >= 100)
        {
          throw new InputInvalidException("Name cannot be longer than 100 characters");
        }
        else
        {
          _userName = value;
        }
      }
    }
  

}

