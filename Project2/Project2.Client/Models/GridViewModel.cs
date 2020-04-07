using System.ComponentModel.DataAnnotations;

namespace Project2.Client.Models
{
  public class GridViewModel
  {
    [Display(Name = "Give your grid a name")]
    [Required(ErrorMessage ="Please enter a name for your grid")]
    public string Name { get; set; }
    
    [Display(Name = "N° of rows")]
    [Required(ErrorMessage ="Please enter the number of columns")]
    public string Height { get; set; }

    [Display(Name = "N° of columns")]
    [Required(ErrorMessage ="Please enter the number of rows")]
    public string Width { get; set; }
    public string GridId { get; set; }
    public string SaveGrid { get; set; }
    public string UserName { get; set; }

  }
}