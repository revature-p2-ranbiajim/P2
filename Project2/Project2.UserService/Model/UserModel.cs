using System.ComponentModel.DataAnnotations;

namespace Project2.UserService.Models
{
  public class UserModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
  }
}