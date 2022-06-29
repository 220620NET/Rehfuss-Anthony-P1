namespace Models;

class FromModel 
{
    // string name = "k";
 //   decimal ticketPrice;
  //  int tickeId;
   // string managerName;

   // string employeeName;
    // public string GetName() 
    // {
    //     return name;

    // }
    // public void SetName(string nameToBeAssigned)
    // {
    //        name = nameToBeAssigned;
    // }
    public FromModel(){}
   
      public FromModel(decimal setTicketPrice, int setTicketId)
    {
         ticketCost = setTicketPrice;
         tickeId = setTicketId;

    }
    
    public string employeeName {get; set;}
    public int empId {get; set;}
    public int ManagerId {get; set;}
    public string managerName {get; set;}
   /// public int tickeId {get; set;}
    public decimal ticketCost {get; set;}
}

