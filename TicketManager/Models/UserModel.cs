namespace Models;



public class User
{
  public int UserId {get;set;}
  public string UserName {get; set;} = "";  //this gets rid of the null warnings
  public string password {get; set;} = "";
  public string role {get; set;} = "";

}