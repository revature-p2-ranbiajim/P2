using System.ComponentModel.DataAnnotations;

namespace Project2.Client.Models
{
  public class UserViewModel
  {
    [Display(Name = "Username")]
    [Required(ErrorMessage ="please enter your username")]
    public string Username { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage ="please enter a valid password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage ="please enter a valid password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "First Name")]
    [Required(ErrorMessage ="please enter your first name")]
    public string FirstName { get; set; }
    
    [Display(Name = "Last Name")]
    [Required(ErrorMessage ="please enter your first name")]
    public string LastName { get; set; }
    public long UserId { get; set; }

  }
}