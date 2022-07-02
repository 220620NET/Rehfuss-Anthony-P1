using CustomExceptions;
namespace Models;



public class User
{

   public User(string UserName, string role) 
   {
      this.Name = UserName="";
      this.role = role="";
   }
   

  private string _name="";
  public string Name
{
       get { return _name;}

       set
       {
        if (String.IsNullOrWhiteSpace(value))
        {
          throw new InputInvalidException("Name must not be empty");
        }
        else //optional
        {
          _name = value;
        }
       }

       
}



  public int Id {get;set;}
 // public string Name {get; set;} = "";  //this gets rid of the null warnings
  public string password {get; set;} = "";
  public string role {get; set;} = "";

  public override string ToString()
  {
    return $"Name: {this.Name} \nrole: {this.role}";
  }

  public override bool Equals(object? obj)
  {
      if(obj.GetType() == this.GetType())
      {
        User usertoCompare = (User) obj;
        if(this.Id == usertoCompare.Id && this.Name == usertoCompare.Name )
        {
           return true;
        }
        return false;
      }
      else
      {
         return false;
      }

  }

}


