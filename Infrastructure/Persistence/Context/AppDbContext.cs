using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().ToContainer("Courses");
        modelBuilder.Entity<User>().ToContainer("Users");
        modelBuilder.Entity<Comment>().ToContainer("Comments");
        modelBuilder.Entity<Book>().ToContainer("Books");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Book> Books { get; set; }
}
