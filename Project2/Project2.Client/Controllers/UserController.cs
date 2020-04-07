using System;
using System.Collections.Generic;
using System.Linq;
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
    CurrentViewModel current = new CurrentViewModel();

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
        if (res.IsSuccessStatusCode){
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
    public async Task<IActionResult> LoginUser(UserViewModel user)
    {
      var Uri = $"http://service_2/api/user?username={user.Username}&password={user.Password}";
      var response = await _http.GetAsync(Uri);
      //if (response.IsSuccessStatusCode)
      // {
        var content = await response.Content.ReadAsStringAsync();
        var userinfo1 = JsonConvert.DeserializeObject<List<string>>(content);
        List<string> userinfo = new List<string>();
        foreach(var item in userinfo1) {
          userinfo.Add(item);
        }

        if (userinfo.Count >= 1)
        {
          UserViewModel tempUser = new UserViewModel() {
            Username = userinfo[0],
            Password = userinfo[1],
            FirstName = userinfo[2],
            LastName = userinfo[3],
            EmailAddress = userinfo[4]
          };
          // return View("UserMenu", tempUser);
        // }
          return View("UserMenu", new UserViewModel());
        }
      return View();
    }

    [HttpGet]
    public IActionResult UserMenu()
    {
      var u = new UserViewModel()
      {
        FirstName = current.currentUserFirstName
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
        current.currentGridName = grid.Name;
        
        var g = new GridViewModel()
        {
          Name = grid.Name,
          Height = grid.Height,
          Width = grid.Width
        };

        return View("NewGrid", g);
      }

      return View("ChooseSizeGrid");
    }

    [HttpPost]
    public IActionResult SaveGrid(GridViewModel grid)
    {
      //TODO: CONNECT TO GRID API TO SAVE GRID AND NAME OF GRID, ALSO VALIDATE IF IT WAS SAVED

      var u = new UserViewModel()
      {
        FirstName = current.currentUserFirstName
      };
      
      return View("UserMenu", u);
    }

    [HttpGet]
    public IActionResult PreviousGrids()
    {
      //TODO: WITH CURRENT USERNAME, CALL API AND GET THE PREVIOUS GRIDS
      
      var u = new UserViewModel()
      {
        FirstName = current.currentUserFirstName,
        Username = current.currentUsername
      };

      return View("PreviousGrids", u);
    }

    [HttpGet]
    public IActionResult LogoutUser()
    {
      var u = new UserViewModel()
      {
        FirstName = current.currentUserFirstName
      };
      return View("LogoutUser", u);
    }

  }
}