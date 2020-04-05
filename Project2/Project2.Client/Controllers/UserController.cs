using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project2.Client.Models;

namespace Project2.Client.Controllers
{
  public class UserController : Controller
  {
    private readonly HttpClient _http = new HttpClient();
    private static string currentUserId;
    private static string currentUserFirstName;

    [HttpGet]
    public IActionResult CreateUser()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserViewModel user)
    {
      if (ModelState.IsValid)
      {
        var dataAsString = JsonConvert.SerializeObject(user);
        var content = new StringContent(dataAsString, Encoding.UTF8, "application/json");
        var res = await _http.PostAsync("http://service_2/api/user", content);
        if (res.StatusCode == HttpStatusCode.OK){
          return View("SuccessfulAccountCreation", user);
        }
      }
      return View();
    }

    [HttpGet]
    public IActionResult LoginUser()
    {
      return View();
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

          currentUserId = user.UserId;
          currentUserFirstName = user.FirstName;

          var u = new UserViewModel()
          {
            FirstName = currentUserFirstName
          };

          return View("UserMenu", u);
        }
      }
      return View();
    }

    [HttpGet]
    public IActionResult UserMenu()
    {
      var u = new UserViewModel()
      {
        FirstName = currentUserFirstName
      };

      return View("UserMenu", u);
    }

    [HttpGet]
    public IActionResult ChooseSizeGrid()
    {
      return View("ChooseSizeGrid");
    }

    [HttpPost]
    public IActionResult ChooseSizeGrid(GridViewModel grid)
    {
      if (ModelState.IsValid)
      {
        var g = new GridViewModel()
        {
          Name = grid.Name,
          Height = grid.Height,
          Width = grid.Width
        };

        //TODO: fix NewGrid, right now is a standard grid, not a customized one

        return View("NewGrid", g);
      }

      return View("ChooseSizeGrid");
    }

    [HttpGet]
    public IActionResult PreviousGrids()
    {
      var u = new UserViewModel()
      {
        FirstName = currentUserFirstName,
        UserId = currentUserId
      };

      return View("PreviousGrids", u);
    }

    [HttpGet]
    public IActionResult LogoutUser()
    {
      var u = new UserViewModel()
      {
        FirstName = currentUserFirstName
      };
      return View("LogoutUser", u);
    }

  }
}