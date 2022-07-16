using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
         options.SerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration
.GetConnectionString("TicketDB")));
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddTransient<UserService>();

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

app.Run();
