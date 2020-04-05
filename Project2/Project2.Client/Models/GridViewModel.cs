using System.ComponentModel.DataAnnotations;

namespace Project2.Client.Models
{
  public class GridViewModel
  {
    [Display(Name = "Grid Name")]
    [Required(ErrorMessage ="please enter a name for your grid")]
    public string Name { get; set; }
    
    [Display(Name = "Number of Columns")]
    [Required(ErrorMessage ="please enter the number of columns")]
    public string Height { get; set; }

    [Display(Name = "Number of Rows")]
    [Required(ErrorMessage ="please enter the number of rows")]
    public string Width { get; set; }
    public int GridId { get; set; }

  }
}