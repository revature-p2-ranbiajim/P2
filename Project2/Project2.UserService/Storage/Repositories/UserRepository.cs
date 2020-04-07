using System;
using System.Collections.Generic;
using System.Linq;
using Project2.UserService.Models;

namespace Project2.UserService.Storage.Repositories
{
  public class UserRepository
  {
    private static UserDbContext _db;

    public UserRepository(UserDbContext dbContext)
    {
      _db = dbContext;
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

    internal IEnumerable<string> Login(string username, string password)
    {
      // var user = FindUser(username);
      // if (user != null)
      // {
      //   if (password == user.Password)
      //   {
      //     List<string> state = new List<string>();
      //     state[0] = user.Username;
      //     state[1] = user.Password;
      //     state[2] = user.FirstName;
      //     state[3] = user.LastName;
      //     state[4] = user.EmailAddress;
      //     return state;
      //   }
      // }
      // return new List<string>();
      return new List<string>() { "username", "password", "firstname", "lastname", "email@email.com" };
    }
  }
}