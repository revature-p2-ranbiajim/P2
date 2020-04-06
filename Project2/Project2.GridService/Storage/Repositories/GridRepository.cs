using System.Collections.Generic;
using System.Linq;
using Project2.GridService.Model;

namespace Project2.GridService.Storage.Repositories
{
  public class GridRepository
  {
    private static GridDbContext _db;

    public GridRepository(GridDbContext dbContext)
    {
      _db = dbContext;
    }

    internal bool AddGrid(GridModel grid)
    {
      _db.GridModels.Add(grid);
      return _db.SaveChanges() == 1;
    }

    internal IEnumerable<GridModel> GetGridsForUser(string username)
    {
      return _db.GridModels.Where( g => g.UserName == username).ToList();
    }

    internal GridModel GetGrid(long id)
    {
      return _db.GridModels.SingleOrDefault( g => g.GridModelId == id);
    }
  }
}