using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Client.Models;

namespace Project2.Client.Controllers
{
  public class UserController: Controller
  {
    private readonly HttpClient _http = new HttpClient();
    private static string currentUser;
    
    [HttpGet]
    public IActionResult LoginUser()
    {
      return View();
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
      return View("CreateUser");
    }

    [HttpPost]
    public IActionResult CreateUser(UserViewModel user)
    {
      if (ModelState.IsValid)
      {
        //TODO: WE NEED TO PASS THE USERNAME
        var res = _http.GetAsync("http://service_2/api/checkusername").GetAwaiter().GetResult().ToString();
        if (res == null)
        {
         //TODO: Push new user to db
          
          var u = new UserViewModel()
          {
            //TODO: FIX HERE
            FirstName = currentUser
          };
          
          return View("SuccessfulAccountCreation", u);
        }
      }
      return View("CreateUser");
    }
    
    [HttpPost]
    public IActionResult LoginUser(UserViewModel user)
    {
      if (ModelState.IsValid)
      {
        //TODO: WE NEED TO PASS THE USERNAME AND PASSWORD
        var res = _http.GetAsync("http://service_2/api/checkuser").GetAwaiter().GetResult().ToString();
        if (res != null)
        {
          currentUser = res;

          var u = new UserViewModel()
          {
            //TODO: FIX HERE
            FirstName = currentUser
          };
          
          return View("UserMenu", u);
        }
      }
      return View("LoginUser");
    }

    [HttpGet]
    public IActionResult UserMenu()
    { 
      return View("UserMenu");
    }

    [HttpGet]
    public IActionResult NewGrid()
    { 
      var u = new UserViewModel()
      {
        //TODO: FIX HERE
        FirstName = currentUser,
        UserId = 0
      };
      
      return View("NewGrid", u);
    }

    [HttpGet]
    public IActionResult GridMenu()
    {
     var u = new UserViewModel()
      {
        //TODO: FIX HERE
        FirstName = currentUser,
        UserId = 0
      };
      
      return View("GridMenu", u);
    }

    [HttpGet]
    public IActionResult LogoutUser()
    {
      var u = new UserViewModel()
      {
        FirstName = currentUser
      };
      return View("LogoutUser", u);
    }

  }
}