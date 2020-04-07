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

    public UserController(UserRepository ur)
    {
      _ur = ur;
    }

    public UserController(ILogger<UserController> logger)
    {
      _logger = logger;
    }

    //return bool if client match
    [HttpGet]
    public List<string> Get(string username, string password)
    {
      return _ur.Login(username, password);
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
