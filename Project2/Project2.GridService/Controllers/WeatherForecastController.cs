using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project2.GridService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // [HttpGet]
        // public void create()
        // {
        //   //string conString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
        //   using (SqlConnection con = new SqlConnection("server=sql_2;database=UserServiceDb;user id=sa;password=Password12345"))
        //   {
        //     SqlCommand command = new SqlCommand("CREATE DATABASE MyDatabase", con);
        //     command.Connection.Open();
        //     command.ExecuteNonQuery();
        //   };
        // }

        [HttpGet]
        public IActionResult Get()
        {
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = rng.Next(-20, 55),
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            // .ToArray();
                      using (SqlConnection con = new SqlConnection("server=sql_2;database=UserServiceDb;user id=sa;password=Password12345"))
          {
            SqlCommand command = new SqlCommand("CREATE DATABASE MyDatabase", con);
            command.Connection.Open();
            command.ExecuteNonQuery();
          };
          return Ok();
        }
    }
}
