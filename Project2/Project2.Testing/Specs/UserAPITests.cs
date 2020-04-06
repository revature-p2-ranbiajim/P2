using Microsoft.Extensions.Logging;
using Project2.UserService.Controllers;
using Project2.UserService.Models;
using Project2.UserService.Storage;
using Project2.UserService.Storage.Repositories;
using Xunit;

namespace Project2.Testing.Specs
{
  public class UserAPITests
  {
    
    private readonly UserRepository _ur;
    private static UserDbContext _db;
    
    private readonly ILogger<UserController> logger = LoggerFactory.Create(o => o.SetMinimumLevel(LogLevel.Debug)).CreateLogger<UserController>();

    // [Theory]
    // [InlineData("Randall1", "password")]
    // public void Test_GetByUsernameAndPassword(string u, string p)
    // {
    //   var sut = new UserController(_ur);
    //   var actual = sut.Get(u, p);
    //   Assert.IsType<string>(actual);
    // }

    [Theory]
    [InlineData("Randall1", "password")]
    public void Test_FindUser(string u)
    {
      var sut = new UserRepository(_db);
      var actual = sut.FindUser(u);
      Assert.True(actual != null);
    }
  }
}