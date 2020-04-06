
using Microsoft.EntityFrameworkCore;
using Project2.UserService.Models;
using System;

namespace Project2.UserService.Storage
{
  public class UserDbContext : DbContext
  {
    public DbSet<UserModel> UserModels { get; set; }
    public UserDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.Entity<UserModel>().HasKey(u => u.Username);

        builder.Entity<UserModel>().Property(u => u.Username).ValueGeneratedNever();
          
        builder.Entity<UserModel>().HasData(new UserModel[]
        {
            new UserModel() { Username = "Randall1", FirstName = "Randall", LastName = "Steinkamp", Password = "password", EmailAddress = "randall@email.com"},
            new UserModel() { Username = "Jim1", FirstName = "Jim", LastName = "Gazaway", Password = "password", EmailAddress = "jim@email.com"},
            new UserModel() { Username = "Bianca1", FirstName = "Bianca", LastName = "Visconti", Password = "password", EmailAddress = "bianca@email.com"}
        });
    }
    }
}