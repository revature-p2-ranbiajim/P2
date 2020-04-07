using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.Client.Controllers;
using Project2.MVC.Controllers;
using Xunit;

namespace Project2.Testing.Specs
{
  public class MVCTests
  {
    private readonly ILogger<HomeController> logger = LoggerFactory.Create(o => o.SetMinimumLevel(LogLevel.Debug)).CreateLogger<HomeController>();
    
    [Fact]
    public void Test_CreateUserReturnsView()
    {
      var sut = new UserController();
      var actual = sut.CreateUser() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }

    [Fact]
    public void Test_LoginUserReturnsView()
    {
      var sut = new UserController();
      var actual = sut.LoginUser() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }

    [Fact]
    public void Test_UserMenuReturnsView()
    {
      var sut = new UserController();
      var actual = sut.UserMenu() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }

    [Fact]
    public void Test_ChooseSizeGridReturnsView()
    {
      var sut = new UserController();
      var actual = sut.ChooseSizeGrid() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }

    // [Fact]
    // public void Test_PreviousGridsReturnsView()
    // {
    //   var sut = new UserController();
    //   var actual = sut.PreviousGrids() as IActionResult;
    //   Assert.IsType<ViewResult>(actual);
    // }

    [Fact]
    public void Test_LogoutUserReturnsView()
    {
      var sut = new UserController();
      var actual = sut.LogoutUser() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }

    [Fact]
    public void Test_IndexReturnsView()
    {
      var sut = new HomeController(logger);
      var actual = sut.Index() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }

    [Fact]
    public void Test_PrivacyReturnsView()
    {
      var sut = new HomeController(logger);
      var actual = sut.Privacy() as IActionResult;
      Assert.IsType<ViewResult>(actual);
    }
    
  }
}