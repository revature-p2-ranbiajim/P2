using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.GridService.Model;
using Project2.GridService.Storage.Repositories;
using System.Collections.Generic;

namespace Project2.GridService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GridController : ControllerBase
  {

    private static GridRepository _gr;
    private readonly ILogger<GridController> _logger;

    public GridController(GridRepository gr)
    {
      _gr = gr;
    }

    public GridController(ILogger<GridController> logger)
    {
      _logger = logger;
    }

    // Get all grids for specific user
    [HttpGet]
    public IEnumerable<GridModel> Get(string username)
    {
      return _gr.GetGridsForUser(username);
    }

    // Get specific grid by ID
    [HttpGet]
    public GridModel Get(long Id)
    {
      return _gr.GetGrid(Id);
    }

    //add new user to the database, USE FROM BODY IF GETTING A MODEL
    [HttpPost]
    public IActionResult Post(GridModel grid)
    {
      if (_gr.AddGrid(grid))
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
