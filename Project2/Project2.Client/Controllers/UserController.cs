using Microsoft.AspNetCore.Mvc;
using Project2.Client.Models;

namespace Project2.Client.Controllers
{
  public class UserController: Controller
  {
    [HttpGet]
    public IActionResult LoginUser()
    {
      return View();
    }

    [HttpPost]
    public IActionResult LoginUser(UserViewModel user)
    {
      
      // if (ModelState.IsValid)
      // {
      //   var acct = _ur.CheckIfAccountExists(user.Name, user.Password);

      //   if (acct)
      //   {
      //     currentUser = _ur.GetUser(user.Name, user.Password);

      //     var u = new UserViewModel()
      //     {
      //       Name = currentUser.Name,
      //       Password = currentUser.Password,
      //       UserId = currentUser.UserId,
      //       Address = currentUser.Address
      //     };
          
      //     return View("UserOptions", u);
      //   }
      // }
      // return View(user);

      return View("LoginUser");
    }
  }
}