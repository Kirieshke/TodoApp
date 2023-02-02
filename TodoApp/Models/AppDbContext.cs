using Microsoft.EntityFrameworkCore;
using TodoApp.Domain; 

namespace TodoApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Task> Tasks{ get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
