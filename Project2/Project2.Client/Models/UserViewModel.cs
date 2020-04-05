using System.ComponentModel.DataAnnotations;

namespace Project2.Client.Models
{
  public class UserViewModel
  {
    [Display(Name = "Username")]
    [Required(ErrorMessage ="Please enter your username")]
    public string Username { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage ="Please enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Passwords must match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "First name")]
    [Required(ErrorMessage ="Please enter your first name")]
    public string FirstName { get; set; }
    
    [Display(Name = "Last name")]
    [Required(ErrorMessage ="Please enter your last name")]
    public string LastName { get; set; }
    public string UserId { get; set; }
    
    [Display(Name = "Email Address")]
    [Required(ErrorMessage ="Please enter your email address")]
    public object EmailAddress { get; internal set; }
  }
}