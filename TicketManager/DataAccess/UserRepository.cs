using Models;
using Microsoft.Data.SqlClient;
using CustomExceptions;
using System.Data;

namespace DataAccess;

public class UserRepository : IUserRepository
{
        private readonly ConnectionFactory _connectionFactory;
        
        public UserRepository()
        {
          _connectionFactory = ConnectionFactory.GetInstance();
        }

        public List<User> GetAllUsers()
        {
              List<User> users =  new List<User>();
              SqlConnection conn = _connectionFactory.GetConnection();

              conn.Open();

              SqlCommand cmd = new SqlCommand("SELECT * from Pro1.Users", conn);
              SqlDataReader reader = cmd.ExecuteReader();

              while(reader.Read())
              {
                users.Add(new User {
                  UserName = (string)reader["username"],
                  Password = (string)reader["password"],
                  Role = (string)reader["user_role"]

              });
              }
              reader.Close();
              conn.Close();
           return users;
        }

  public User GetUser(string name)
  {
       User foundUser;
       SqlConnection conn = _connectionFactory.GetConnection();
       conn.Open();

       SqlCommand cmd = new SqlCommand("Select * From Pro1.Users where username = @name", conn);

       cmd.Parameters.AddWithValue("@name", name);
       SqlDataReader reader = cmd.ExecuteReader();

       while(reader.Read())
       {
             return new User
             {
              UserName = (string)reader["username"],
                  Password = (string)reader["password"],
                  Role = (string)reader["user_role"]
            };
       }
       throw new RecordNotFoundException("Could not find such a name");
  }

/// <summary>
/// Adds a new User record to db
/// </summary>
/// <param name="newUserToRegister"></param>
/// <returns>the same user </returns>
public User AddUser(User newUserToRegister)
{     
     // disconneted architecture ADO.NET
     // Dataset is a container for the data adapter to fill with data it fetches with the select command
      DataSet UserSet = new DataSet();

      SqlDataAdapter UserAdapter = new SqlDataAdapter("SELECT * from Pro1.Users",_connectionFactory.GetConnection());
      UserAdapter.Fill(UserSet, "UserTable");

      //question mark(?) after a reference type makes it nullable as in, this UserTable variable can either be DataTable or null

      DataTable? UserTable = UserSet.Tables["UserTable"];
      if(UserTable != null)
      {
        DataRow newUser = UserTable.NewRow();
        newUser["username"] = newUserToRegister.UserName;
        newUser["password"] = newUserToRegister.Password;
        newUser["user_role"] = newUserToRegister.Role;

        UserTable.Rows.Add(newUser);

        SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(UserAdapter);

        SqlCommand insertCommand = cmdbuilder.GetInsertCommand();
        UserAdapter.InsertCommand = insertCommand;

        UserAdapter.Update(UserTable);
      }
      return newUserToRegister;
}

}