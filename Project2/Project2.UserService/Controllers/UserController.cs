using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;
using Project2.UserService.Models;

namespace Project2.UserService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly ILogger<UserController> _logger;
    private static string _sqlCon = @"server=sql_2;database=UserServiceDb;user id=sa;password=Password12345";

    public UserController(ILogger<UserController> logger)
    {
      _logger = logger;
    }

    //return the ClientId of given username and password if they match
    [HttpGet]
    public int Get(string username, string password)
    {
      using (SqlConnection myCon = new SqlConnection(_sqlCon))
      using(SqlCommand command = new SqlCommand("Select ClientId FROM dbo.CLIENT WHERE Username=@userName AND Password=@password", myCon))
      {
        // string sql = "Select ClientId FROM dbo.CLIENT WHERE Username=@userName AND Password=@password";
        // SqlCommand command = new SqlCommand(sql, _sqlCon);
        myCon.Open();
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@userName", username);
        command.Parameters.AddWithValue("@password", password);
        var result = command.ExecuteNonQuery();
        return (int)result;
      };
    }

    //add new user to the database
    [HttpPost]
    //public IActionResult Post(string userName, string firstName, string lastName, string emailAddress, string password){
      public IActionResult Post(UserModel user){
        // return Ok();
      using (SqlConnection myCon = new SqlConnection(_sqlCon))
      using(SqlCommand command = new SqlCommand("INSERT INTO dbo.CLIENT (Username, Password, FirstName, LastName, EmailAddress) VALUES (@userName, @password, @firstName, @lastName, @emailAddress", myCon))
      {
        myCon.Open();
        if (!UserExists(user.Username, myCon))
        {
          // string sql = "INSERT INTO dbo.CLIENT (Username, Password, FirstName, LastName, EmailAddress) VALUES (@userName, @password, @firstName, @lastName, @emailAddress";
          // SqlCommand command = new SqlCommand(sql, _sqlCon);
          
          command.Parameters.AddWithValue("@userName", user.Username);
          command.Parameters.AddWithValue("@firstName", user.FirstName);
          command.Parameters.AddWithValue("@lastName", user.LastName);
          command.Parameters.AddWithValue("@emailAddress", user.EmailAddress);
          command.Parameters.AddWithValue("@password", user.Password);
          // _sqlCon.Open();
          // command.ExecuteReader();
          // if (result >= 0)
          // {
            return Ok();
          // }
        }
      };
      return BadRequest();
    }

    //Username check to see if a user is already in the database. Might not be necessary since I'm doing a check on the result when posting a user.
    private bool UserExists(string userName, SqlConnection myCon)
    {
      // using (myCon)
      // {
      //   myCon.Open();
        // string sql = "Select ClientId FROM dbo.CLIENT WHERE Username=@userName";
        // SqlCommand command = new SqlCommand(sql, myCon);
        // command.Parameters.AddWithValue("@userName", userName);
        // var result = command.ExecuteScalar();
        // return result != null? true : false;
        return false;
      // }
    }
  }
}
