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
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;


    // [HttpGet]
    // //[Route("tables")]
    // public IEnumerable<string> Get()
    // {
    //   List<string> res = new List<string>();
    //   using (SqlConnection con = new SqlConnection("server=sql_2;database=UserServiceDb;user id=sa;password=Password12345"))
    //   {
    //       DataTable dt = con.GetSchema("Tables");
    //       foreach(DataRow row in dt.Rows)
    //       {
    //           string table = row[2] as string;
    //           res.Add(table);
    //       }
    //     // SqlCommand command = new SqlCommand("CREATE DATABASE MyDatabase", con);
    //     // command.Connection.Open();
    //     // command.ExecuteNonQuery();
    //   };
    //   return res;
    // }
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    //public IEnumerable<WeatherForecast> Get()
    public IEnumerable<string> Get()
    {
      //   var rng = new Random();
      //   return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      //   {
      //     Date = DateTime.Now.AddDays(index),
      //     TemperatureC = rng.Next(-20, 55),
      //     Summary = Summaries[rng.Next(Summaries.Length)]
      //   })
      //   .ToArray();
      List<string> res = new List<string>();
      using (SqlConnection con = new SqlConnection("server=sql_2;database=UserServiceDb;user id=sa;password=Password12345"))
      {
        con.Open();
        DataTable dt = con.GetSchema("Tables");
        foreach (DataRow row in dt.Rows)
        {
          string table = row[2] as string;
          res.Add(table);
        }
        // SqlCommand command = new SqlCommand("CREATE DATABASE MyDatabase", con);
        // command.Connection.Open();
        // command.ExecuteNonQuery();
      };
      return res;

      //             using (SqlConnection con = new SqlConnection("server=sql_2;database=master;user id=sa;password=Password12345"))
      // {
      //   SqlCommand command = new SqlCommand("CREATE DATABASE MyDatabase", con);
      //   command.Connection.Open();
      //   command.ExecuteNonQuery();
      // };
      // return Ok();
    }
  }
}
