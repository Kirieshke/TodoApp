using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entity;

namespace TodoApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Core.Entity.Task> Tasks{ get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
