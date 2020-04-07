using System.ComponentModel.DataAnnotations;

namespace Project2.GridService.Model
{
  public class GridModel
  {
    public long GridId { get; set; } //primary key
    public string SaveGrid { get; set; } // grid info 
    public string UserName { get; set; }  //associated user
    public string Name { get; set; }
    public string Height { get; set; }
    public string Width { get; set; }
  }
}