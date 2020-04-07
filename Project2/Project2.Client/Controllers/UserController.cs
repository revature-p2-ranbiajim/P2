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
    private CurrentViewModel _current = new CurrentViewModel();

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
    public IActionResult LoginUser(UserViewModel user)
    {
      var Uri = $"http://service_2/api/user?username={user.Username}&password={user.Password}";
      var response = _http.GetAsync(Uri).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
      UserViewModel givenUser = JsonConvert.DeserializeObject<UserViewModel>(response);
      //current = givenUser;
      return View("UserMenu", givenUser);
    }

    [HttpGet]
    public IActionResult UserMenu()
    {
      var u = new UserViewModel()
      {
        FirstName = _current.currentUserFirstName
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
        _current.currentGridName = grid.Name;
        
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
    public async Task<IActionResult> SaveGrid(GridViewModel grid)
    {
      //TODO: CONNECT TO GRID API TO SAVE GRID AND NAME OF GRID, ALSO VALIDATE IF IT WAS SAVED
      if (ModelState.IsValid)
      {
        var dataAsString = JsonConvert.SerializeObject(grid);
        var content = new StringContent(dataAsString, Encoding.UTF8, "application/json");
        var res = await _http.PostAsync("http://service_1/api/grid", content);

        if (res.IsSuccessStatusCode)
        {
          var u = new UserViewModel()
          {
            FirstName = _current.currentUserFirstName
          };
          return View("UserMenu", u);
        }
      }
      return View();
    }

    [HttpGet]
    public IActionResult PreviousGrids()
    {
      //TODO: WITH CURRENT USERNAME, CALL API AND GET THE PREVIOUS GRIDS
      var Uri = $"http://service_2/api/grid?username={_current.currentUsername}";
      var response = _http.GetAsync(Uri).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
      List<GridViewModel> grids = JsonConvert.DeserializeObject<List<GridViewModel>>(response);
      
      var u = new UserViewModel()
      {
        FirstName = _current.currentUserFirstName,
        Username = _current.currentUsername
      };

      return View("PreviousGrids", u);
    }

    [HttpGet]
    public IActionResult LogoutUser()
    {
      var u = new UserViewModel()
      {
        FirstName = _current.currentUserFirstName
      };
      return View("LogoutUser", u);
    }

  }
}