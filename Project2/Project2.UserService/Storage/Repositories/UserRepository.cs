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

    public bool AddUser(UserModel user)
    {
      _db.UserModels.Add(user);
      return _db.SaveChanges() == 1;
    }

    // public List<string> Login(string username, string password)
    // {
    //   var user = FindUser(username);
    //   if (user != null)
    //   {
    //     if (password == user.Password)
    //     {
    //       List<string> state = new List<string>();
    //       state.Add(user.Username);
    //       state.Add(user.Password);
    //       state.Add(user.FirstName);
    //       state.Add(user.LastName);
    //       state.Add(user.EmailAddress);
    //       return state;
    //     }
    //   }
    //   return new List<string>();
    // }
  }
}