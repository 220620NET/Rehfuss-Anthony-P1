using CustomExceptions;

namespace Models;

public class Ticket
{
   
   public int Id {get; set;}
   public string Author {get; set;}
   public string Resolover {get; set;}
   public string Description {get; set;}
   public string Status {get; set;}
   public decimal Amount {get; set;}

   public Ticket(int Id, string Author, string Resolover, string Description, string Status, decimal Amount )
   {
      this.Id = Id;
      this.Author = Author;
      this.Resolover = Resolover;
      this.Description = Description;
      this.Status = Status;
      this.Amount = Amount;
   }
  
   public Ticket(string Author, string Resolover)
   {
      this.Author = Author; 

      this.Resolover = Resolover;
   }

  public override string ToString()
  {
    return "Id: " + this.Id +
    ", Author: " + Author +
    ", Resolver: " + Resolover +
    ", Description: " + Description +
    ", Status: " + Status + 
    ", Amount: " + Amount;
  }

  public override bool Equals(object? obj)
  {
    if(obj.GetType() == this.GetType())
    {
      Ticket ticketToCompare = (Ticket) obj;
      
      if(this.Id == ticketToCompare.Id && this.Author == ticketToCompare.Author )
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

