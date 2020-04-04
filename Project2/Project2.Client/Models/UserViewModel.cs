using System.ComponentModel.DataAnnotations;

namespace Project2.Client.Models
{
  public class UserViewModel
  {
    [Display(Name = "Username")]
    [Required(ErrorMessage ="please enter your username")]
    public string Userame { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage ="please enter a valid password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public long UserId { get; set; }

  }
}