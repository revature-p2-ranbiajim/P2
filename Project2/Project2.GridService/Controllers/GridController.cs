using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.GridService.Model;
using System.Data.SqlClient;

namespace Project2.GridService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GridController : ControllerBase
  {

    //STORE GRID USERNAME, GRIDMODEL
    private readonly ILogger<GridController> _logger;

    public GridController(ILogger<GridController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public string Get(string username)
    {    
      // using(SqlCommand command = new SqlCommand("Select Username FROM CLIENT WHERE Username=@userName AND Password=@password", _myCon))
      // {
      //   _myCon.Open();
      //   command.Parameters.AddWithValue("@userName", username);
      //   command.Parameters.AddWithValue("@password", password);
      //   var result = command.ExecuteScalar() as string;
      //   return result;
      // };
      return "";
    }

    //add new user to the database, USE FROM BODY IF GETTING A MODEL
    [HttpPost]
      public IActionResult Post(string username, GridModel grid){
      // using (_myCon)
      // {
      //     string sql = "INSERT INTO CLIENT (Username, Password, FirstName, LastName, EmailAddress) VALUES (@userName, @password, @firstName, @lastName, @emailAddress)";
      //     SqlCommand command = new SqlCommand(sql, _myCon);
          
      //     command.Parameters.AddWithValue("@userName", user.Username);
      //     command.Parameters.AddWithValue("@firstName", user.FirstName);
      //     command.Parameters.AddWithValue("@lastName", user.LastName);
      //     command.Parameters.AddWithValue("@emailAddress", user.EmailAddress);
      //     command.Parameters.AddWithValue("@password", user.Password);
      //     _myCon.Open();
      //     var res = command.ExecuteNonQuery();
      //     if (res >= 0)
      //     {
      //       return Ok();
      //     }
      // };
      return BadRequest();
    }
  }
}
