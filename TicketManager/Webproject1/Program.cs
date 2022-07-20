using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration
.GetConnectionString("TicketDB")));
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddTransient<UserService>();

builder.Services.AddScoped<ITicketRepository,TicketReimbursementRepository>();
builder.Services.AddScoped<TicketService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();




app.MapGet("/", () => "Hello World!");

app.MapGet("/greet/{name}", (string name)=>{
    
             return $"Hi {name}!";
});

app.MapGet("/greet", (string name) =>{
           return $"Hello {name}!";
});

app.MapPost("/greet", (string name)=>{
  return $"Hello {name}";
});

app.MapGet("/Users", () =>{
  var scope = app.Services.CreateScope();
  UserService service = scope.ServiceProvider.GetRequiredService<UserService>();

  return service.GetAllUsers();
});

app.MapPost("/register", (User user)=>
{
      var scope = app.Services.CreateScope();
      AuthServices services = scope.ServiceProvider.GetRequiredService<AuthServices>();

      try
      {
          services.Register(user);
          return Results.Created("/register", user);
      }
      catch
      {
           return Results.Conflict("User with this name already exists");
      }
});

app.MapGet("/User",(string user)=>{
     var scope = app.Services.CreateScope();
     UserService service = scope.ServiceProvider.GetRequiredService<UserService>();

    // service.GetUser(user);
     return service.GetUser(user);
});

app.MapPost("Login",(string name, string login)=>{
   var scope = app.Services.CreateScope();
     UserService service = scope.ServiceProvider.GetRequiredService<UserService>();

     return service.Login(name,login);


} );


app.MapPost("/newTicket", (Ticket ticket)=>
{
      var scope = app.Services.CreateScope();
      TicketService service = scope.ServiceProvider.GetRequiredService<TicketService>();

      try
      {
          service.AddTicket(ticket);
          return Results.Created("/newTicket", ticket);
      }    
      catch
      {
           return Results.Conflict("Ticket with Id already exists");
      }
});

app.MapPost("/updateTicket", (int id, string status) =>
{
      var scope = app.Services.CreateScope();
      TicketService service = scope.ServiceProvider.GetRequiredService<TicketService>();
     return service.UpDateTicket(id,status);
     
});

app.MapGet("/Tickets",()=>
{
       var scope = app.Services.CreateScope();
       TicketService service = scope.ServiceProvider.GetRequiredService<TicketService>();

       return service.GetTickets();

});

app.MapPost("/TicketsByStatus",(string status)=>
{
    var scope = app.Services.CreateScope();
    TicketService service = scope.ServiceProvider.GetRequiredService<TicketService>();

    return service.getTicketsByStatus(status);

});


app.MapPost("/TicketBysAuthor",(string author)=>
{
       var scope = app.Services.CreateScope();
       TicketService service = scope.ServiceProvider.GetRequiredService<TicketService>();

       return service.getTicketsByAuthor(author);

});

app.MapPost("/TicketId",(int id) =>{
       var scope = app.Services.CreateScope();
      TicketService services = scope.ServiceProvider.GetRequiredService<TicketService>();
      return services.getTicketId(id);
});




app.Run();
