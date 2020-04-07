using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.UserService.Models;
using Project2.UserService.Storage.Repositories;

namespace Project2.UserService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private static UserRepository _ur;
    private readonly ILogger<UserController> _logger;

    public UserController(UserRepository ur, ILogger<UserController> logger)
    {
      _ur = ur;
      _logger = logger;
    }

    // public UserController(ILogger<UserController> logger)
    // {
      
    // }

    //return user if client match
    [HttpGet]
    public UserModel Get(string username, string password)
    {
      var user = _ur.FindUser(username);
      if (user.Password == password)
      {
        return user;
      }
      return null;
    }

    //add new user to the database
    [HttpPost]
    public IActionResult Post([FromBody]UserModel user)
    {
      if (_ur.FindUser(user.Username) != null)
      {
        if (_ur.AddUser(user))
        {
          return Ok();
        }
      }
      return BadRequest();
    }
  }
}
