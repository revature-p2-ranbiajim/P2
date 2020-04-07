
using Microsoft.EntityFrameworkCore;
using Project2.GridService.Model;
using System;

namespace Project2.GridService.Storage
{
  public class GridDbContext : DbContext
  {
    public DbSet<GridModel> GridModels { get; set; }
    public GridDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<GridModel>().HasKey(u => u.GridId);

      builder.Entity<GridModel>().Property(u => u.GridId).ValueGeneratedNever();
    }
  }
}