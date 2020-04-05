using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;

namespace Project2.UserService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly ILogger<UserController> _logger;
    private SqlConnection _sqlCon = new SqlConnection("server=sql_2;database=UserServiceDb;user id=sa;password=Password12345");

    public UserController(ILogger<UserController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
      List<string> res = new List<string>();
      using (_sqlCon)
      {
        _sqlCon.Open();
        DataTable dt = _sqlCon.GetSchema("Tables");
        foreach (DataRow row in dt.Rows)
        {
          string table = row[2] as string;
          res.Add(table);
        }
      };
      return res;
    }

    [HttpPost]
    public IActionResult PostUser(string userName, string firstName, string lastName, string emailAddress, string password){
      using (_sqlCon)
      {
        if (!UserExists(userName))
        {
          string sql = "INSERT INTO dbo.CLIENT (Username, Password, FirstName, LastName, EmailAddress) VALUES (@userName, @password, @firstName, @lastName, @emailAddress";
          SqlCommand command = new SqlCommand(sql, _sqlCon);
          command.Parameters.AddWithValue("@userName", userName);
          command.Parameters.AddWithValue("@firstName", firstName);
          command.Parameters.AddWithValue("@lastName", lastName);
          command.Parameters.AddWithValue("@emailAddress", emailAddress);
          command.Parameters.AddWithValue("@password", password);
          _sqlCon.Open();
          int result = command.ExecuteNonQuery();
          _sqlCon.Close();
          if (result >= 0)
          {
            return Ok();
          }
        }
      };
      return BadRequest();
    }

    private bool UserExists(string userName)
    {
      using (_sqlCon)
      {
        string sql = "Select ClientId FROM dbo.CLIENT where Username=@userName";
        SqlCommand command = new SqlCommand(sql, _sqlCon);
        command.Parameters.AddWithValue("@userName", userName);
        var result = command.ExecuteScalar();
        return result != null? true : false;
      }
      
    }
  }
}
