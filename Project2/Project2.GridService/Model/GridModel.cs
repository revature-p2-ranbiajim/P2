using System.ComponentModel.DataAnnotations;

namespace Project2.GridService.Model
{
  public class GridModel
  {
    public long GridModelId { get; set; } //primary key
    public string GridModelInfo { get; set; } // grid info 
    public string UserName { get; set; }  //associated user
  }
}