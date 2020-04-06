using System;
using System.Linq;
using Project2.UserService.Models;

namespace Project2.UserService.Storage.Repositories
{
  public class UserRepository
  {
    private static UserDbContext _db;
    // private static readonly UserRepository _self = new UserRepository(_db);

    public UserRepository(UserDbContext dbContext)
    {
      _db = dbContext;
    }

    internal string GetFirstName(string username, string password)
    {
      var user = FindUser(username);
      if (user != null && user.Password == password)
      {
        return user.FirstName;
      }
      return "";
    }

    public UserModel FindUser(string username)
    {
      return _db.UserModels.SingleOrDefault( u => u.Username == username);
    }

    internal bool AddUser(UserModel user)
    {
      _db.UserModels.Add(user);
      return _db.SaveChanges() == 1;
    }
  }
}