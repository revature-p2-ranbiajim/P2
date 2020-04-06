using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Project2.UserService.Models;

namespace Project2.UserService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly ILogger<UserController> _logger;
    private static string _conString = "server=sql_2;database=UserServiceDb;user id=sa;password=Password12345";
    private SqlConnection _myCon = new SqlConnection(_conString);

    public UserController(ILogger<UserController> logger)
    {
      _logger = logger;
    }

    //return the ClientId of given username and password if they match
    [HttpGet]
    public string Get(string username, string password)
    {
      
      using(SqlCommand command = new SqlCommand("Select Username FROM CLIENT WHERE Username=@userName AND Password=@password", _myCon))
      {
        _myCon.Open();
        command.Parameters.AddWithValue("@userName", username);
        command.Parameters.AddWithValue("@password", password);
        var result = command.ExecuteScalar() as string;
        return result;
      };
    }

    //add new user to the database
    [HttpPost]
      public IActionResult Post([FromBody]UserModel user){
      using (_myCon)
      {
        if (!UserExists(user.Username, _myCon))
        {
          string sql = "INSERT INTO CLIENT (Username, Password, FirstName, LastName, EmailAddress) VALUES (@userName, @password, @firstName, @lastName, @emailAddress)";
          SqlCommand command = new SqlCommand(sql, _myCon);
          
          command.Parameters.AddWithValue("@userName", user.Username);
          command.Parameters.AddWithValue("@firstName", user.FirstName);
          command.Parameters.AddWithValue("@lastName", user.LastName);
          command.Parameters.AddWithValue("@emailAddress", user.EmailAddress);
          command.Parameters.AddWithValue("@password", user.Password);
          _myCon.Open();
          var res = command.ExecuteNonQuery();
          if (res >= 0)
          {
            return Ok();
          }
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
